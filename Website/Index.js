
var app = new Vue({
    el: "#app",
    data: {
        XC: 0,
        YC: 0
    }
});

var colorHolder;
var radiusHolder;

document.getElementById("canvasId").onclick = () => {
    updateCoordinates();
    createCircle(app.XC, app.YC);
};


document.getElementById("initPost").onclick = () => {

    axios({
        method: "post",
        url: "https://localhost:44358/api/values",
        data: {
            X: app.XC,
            Y: app.YC,
            Time: new Date(),
            Color: colorHolder ?? getRandomColor(),
            Diameter: radiusHolder ? 2 * radiusHolder : 2 * getValidRadius(app.XC, app.YC)
        }
    });
};






function updateCoordinates() {
    app.XC = document.documentElement.scrollLeft <= 0 ? event.clientX : event.clientX + document.documentElement.scrollLeft;
    app.YC = document.documentElement.scrollTop <= 0 ? event.clientY : event.clientY + document.documentElement.scrollTop;
}

function getRandomColor() {
    return '#' + Math.floor(Math.random() * 16777215).toString(16).padStart(6, '0');
}

function getValidRadius(x, y) {
    const min = x > y ? y : x;
    return Math.floor(Math.random() * min);
}

function createCircle(x, y) {
    radiusHolder = getValidRadius(x, y);
    colorHolder = getRandomColor();

    //const container = document.createElementNS("http://www.w3.org/2000/svg.html", "svg");
    //container.setAttribute("width", "1000");
    //container.setAttribute("height", "1000");

    const circle = document.createElementNS("http://www.w3.org/2000/svg", "circle");
    circle.setAttribute("cx", app.XC);
    circle.setAttribute("cy", app.YC);
    circle.setAttribute("r", radiusHolder.toString());
    circle.setAttribute("stroke", colorHolder);
    circle.setAttribute("stroke-width", "3");

    //container.appendChild(circle);

    document.getElementById("app").appendChild(circle);
}