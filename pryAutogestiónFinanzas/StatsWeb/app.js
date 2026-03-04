// =============================
// Config
// =============================
const API_BASE = "https://localhost:7245/api"; // <-- ajustá si cambia el puerto

// =============================
// Helpers DOM
// =============================
const $ = (id) => document.getElementById(id);

function fmtMoney(n) {
    const v = Number(n ?? 0);
    return v.toLocaleString("es-AR", { style: "currency", currency: "ARS" });
}

function fmtPct(v) {
    if (v === null || v === undefined) return "N/A";
    return `${Number(v).toFixed(2)}%`;
}

async function getJson(url) {
    const res = await fetch(url);
    if (!res.ok) {
        const text = await res.text();
        throw new Error(`HTTP ${res.status}: ${text}`);
    }
    return res.json();
}

function setStatus(ok, msg) {
    const el = $("status");
    el.textContent = msg;
    el.className = ok ? "status statusOk" : "status statusBad";
}

function setDefaults() {
    const now = new Date();
    $("mes").value = now.getMonth() + 1;
    $("anio").value = now.getFullYear();
    $("apiBaseLabel").textContent = API_BASE;
}

// =============================
// Simple Bar Chart (Canvas) - offline
// =============================
function drawBarChart(canvas, labels, values, opts = {}) {
    const ctx = canvas.getContext("2d");

    // Handle HiDPI
    const dpr = window.devicePixelRatio || 1;
    const cssWidth = canvas.clientWidth || canvas.width;
    const cssHeight = canvas.clientHeight || canvas.height;

    canvas.width = Math.floor(cssWidth * dpr);
    canvas.height = Math.floor(cssHeight * dpr);
    ctx.setTransform(dpr, 0, 0, dpr, 0, 0);

    const width = cssWidth;
    const height = cssHeight;

    // Options
    const title = opts.title || "";
    const maxBars = opts.maxBars || labels.length;
    const barColor = opts.barColor || "rgba(96, 165, 250, 0.85)";   // celeste
    const barColor2 = opts.barColor2 || "rgba(79, 70, 229, 0.85)";  // indigo
    const gridColor = "rgba(255,255,255,0.07)";
    const textColor = "rgba(234,240,255,0.88)";
    const mutedColor = "rgba(169,182,211,0.85)";

    // Prepare
    ctx.clearRect(0, 0, width, height);

    const pad = 14;
    const topPad = title ? 28 : 12;
    const leftPad = 40;
    const rightPad = 12;
    const bottomPad = opts.showXAxis ? 34 : 12;

    const plotX = leftPad;
    const plotY = topPad;
    const plotW = width - leftPad - rightPad;
    const plotH = height - topPad - bottomPad;

    // Title
    if (title) {
        ctx.fillStyle = textColor;
        ctx.font = "700 12px system-ui, -apple-system, Segoe UI, Roboto, Arial";
        ctx.fillText(title, pad, 16);
    }

    // Max value
    const maxVal = Math.max(0, ...values);
    const niceMax = maxVal === 0 ? 1 : maxVal;

    // Y grid lines (4)
    const lines = 4;
    ctx.strokeStyle = gridColor;
    ctx.lineWidth = 1;
    ctx.font = "600 11px system-ui, -apple-system, Segoe UI, Roboto, Arial";
    ctx.fillStyle = mutedColor;

    for (let i = 0; i <= lines; i++) {
        const y = plotY + (plotH * i) / lines;
        ctx.beginPath();
        ctx.moveTo(plotX, y);
        ctx.lineTo(plotX + plotW, y);
        ctx.stroke();

        // y labels
        const val = (niceMax * (lines - i)) / lines;
        const txt = fmtCompact(val);
        ctx.fillText(txt, 6, y + 4);
    }

    // Bars
    const count = Math.min(labels.length, maxBars);
    if (count === 0) return;

    const gap = opts.gap ?? 6;
    const barW = Math.max(3, (plotW - gap * (count - 1)) / count);

    for (let i = 0; i < count; i++) {
        const v = values[i] ?? 0;
        const h = (v / niceMax) * plotH;

        const x = plotX + i * (barW + gap);
        const y = plotY + plotH - h;

        // gradient bar
        const grad = ctx.createLinearGradient(0, y, 0, y + h);
        grad.addColorStop(0, barColor);
        grad.addColorStop(1, barColor2);
        ctx.fillStyle = grad;

        roundRect(ctx, x, y, barW, h, 6);
        ctx.fill();

        // Optional x-axis labels (light)
        if (opts.showXAxis) {
            const lx = x + barW / 2;
            const ly = plotY + plotH + 18;
            ctx.save();
            ctx.translate(lx, ly);
            ctx.rotate(opts.rotateLabels ? (-Math.PI / 6) : 0);
            ctx.fillStyle = mutedColor;
            ctx.font = "600 10px ui-monospace, SFMono-Regular, Menlo, Consolas";
            const label = labels[i];
            const text = (label.length > 10) ? label.slice(0, 10) + "…" : label;
            ctx.textAlign = "center";
            ctx.fillText(text, 0, 0);
            ctx.restore();
        }
    }
}

function fmtCompact(n) {
    const v = Number(n ?? 0);
    if (v >= 1_000_000) return (v / 1_000_000).toFixed(1) + "M";
    if (v >= 1_000) return (v / 1_000).toFixed(1) + "k";
    return Math.round(v).toString();
}

function roundRect(ctx, x, y, w, h, r) {
    const radius = Math.min(r, w / 2, h / 2);
    ctx.beginPath();
    ctx.moveTo(x + radius, y);
    ctx.arcTo(x + w, y, x + w, y + h, radius);
    ctx.arcTo(x + w, y + h, x, y + h, radius);
    ctx.arcTo(x, y + h, x, y, radius);
    ctx.arcTo(x, y, x + w, y, radius);
    ctx.closePath();
}

// =============================
// Load + Render
// =============================
async function cargar() {
    const mes = Number($("mes").value);
    const anio = Number($("anio").value);

    // Balance histórico
    const hist = await getJson(`${API_BASE}/estadisticas/balance-historico`);
    $("histIngresos").textContent = fmtMoney(hist.totalIngresos);
    $("histEgresos").textContent = fmtMoney(hist.totalEgresos);
    $("histBalance").textContent = fmtMoney(hist.balance);

    // Resumen mensual
    const resumen = await getJson(`${API_BASE}/estadisticas/resumen?mes=${mes}&anio=${anio}`);
    $("mesIngresos").textContent = fmtMoney(resumen.totalIngresos);
    $("mesEgresos").textContent = fmtMoney(resumen.totalEgresos);
    $("mesBalance").textContent = fmtMoney(resumen.balance);

    // Comparación mensual
    const comp = await getJson(`${API_BASE}/estadisticas/comparacion-mensual?mes=${mes}&anio=${anio}`);

    $("varIng").textContent = fmtPct(comp.varIngresosPct);
    $("varEgr").textContent = fmtPct(comp.varEgresosPct);

    const compTxt =
        `Mes actual (${comp.mes}/${comp.anio})
Ingresos: ${fmtMoney(comp.ingresosMesActual)}   | Egresos: ${fmtMoney(comp.egresosMesActual)}

Mes anterior (${comp.mesAnterior}/${comp.anioAnterior})
Ingresos: ${fmtMoney(comp.ingresosMesAnterior)} | Egresos: ${fmtMoney(comp.egresosMesAnterior)}

Variación ingresos: ${fmtPct(comp.varIngresosPct)}
Variación egresos:  ${fmtPct(comp.varEgresosPct)}
`;
    $("comparacion").textContent = compTxt;

    // Top categorías (Egresos)
    const top = await getJson(`${API_BASE}/estadisticas/top-categorias?mes=${mes}&anio=${anio}&tipo=Egreso&top=5`);
    const tbody = $("topEgresosBody");
    tbody.innerHTML = "";
    top.forEach(row => {
        const tr = document.createElement("tr");
        tr.innerHTML = `<td>${row.categoria}</td><td class="right">${fmtMoney(row.total)}</td>`;
        tbody.appendChild(tr);
    });

    // Chart Top
    const topLabels = top.map(x => x.categoria);
    const topValues = top.map(x => x.total);
    drawBarChart($("chartTop"), topLabels, topValues, {
        title: "Top 5 por total",
        showXAxis: true,
        rotateLabels: true,
        gap: 10
    });

    // Serie diaria (Egresos)
    const serie = await getJson(`${API_BASE}/estadisticas/serie-diaria?mes=${mes}&anio=${anio}&tipo=Egreso`);
    const labels = serie.map(x => String(x.dia));
    const values = serie.map(x => x.total);

    drawBarChart($("chartDiario"), labels, values, {
        title: "Egresos diarios",
        showXAxis: false,
        gap: 4
    });
}

function wireEvents() {
    $("btnCargar").addEventListener("click", async () => {
        try {
            setStatus(true, "Cargando…");
            await cargar();
            setStatus(true, "Conectado");
        } catch (err) {
            setStatus(false, "Error");
            alert("Error cargando estadísticas:\n" + err.message);
            console.error(err);
        }
    });

    $("btnHoy").addEventListener("click", () => {
        const now = new Date();
        $("mes").value = now.getMonth() + 1;
        $("anio").value = now.getFullYear();
        $("btnCargar").click();
    });

    // Redraw charts on resize (para que quede siempre lindo)
    window.addEventListener("resize", () => {
        // Si ya hay datos cargados, recargar es lo más simple y robusto
        // (y sigue siendo rápido porque son pocos endpoints)
        $("btnCargar").click();
    });
}

document.addEventListener("DOMContentLoaded", () => {
    setDefaults();
    wireEvents();
    $("btnCargar").click(); // autoload
});