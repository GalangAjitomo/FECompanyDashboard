window.productionCharts = window.productionCharts || {};
window.productionCharts.instances = window.productionCharts.instances || {};

function destroyIfExists(id) {
    if (window.productionCharts.instances[id]) {
        window.productionCharts.instances[id].destroy();
    }
}

window.productionCharts.drawLine = function (canvasId, payload) {
    const canvas = document.getElementById(canvasId);
    if (!canvas) return;

    destroyIfExists(canvasId);

    window.productionCharts.instances[canvasId] = new Chart(canvas, {
        type: "line",
        data: payload,
        options: {
            responsive: true,
            maintainAspectRatio: false,
            tension: 0.35,
            plugins: {
                legend: { position: "top" }
            },
            scales: {
                y: { beginAtZero: true }
            }
        }
    });
};

window.productionCharts.drawBar = function (canvasId, payload) {
    const canvas = document.getElementById(canvasId);
    if (!canvas) return;

    destroyIfExists(canvasId);

    window.productionCharts.instances[canvasId] = new Chart(canvas, {
        type: "bar",
        data: payload,
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: { position: "top" }
            },
            scales: {
                y: { beginAtZero: true }
            }
        }
    });
};

window.productionCharts.drawDonut = function (canvasId, payload) {
    const canvas = document.getElementById(canvasId);
    if (!canvas) return;

    destroyIfExists(canvasId);

    window.productionCharts.instances[canvasId] = new Chart(canvas, {
        type: "doughnut",
        data: payload,
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: { position: "bottom" }
            }
        }
    });
};
