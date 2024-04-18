var r = Math.floor(Math.random() * 256); // Red (0-255)
var g = Math.floor(Math.random() * 256); // Green (0-255)
var b = Math.floor(Math.random() * 256); // Blue (0-255)

// Atualize a cor da borda da div
document.getElementById("bordaRGB").style.borderColor = "rgb(" + r + ", " + g + ", " + b + ")";
