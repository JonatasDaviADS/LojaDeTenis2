
document.addEventListener("DOMContentLoaded", function () {
  const toggleBtn = document.getElementById("themeToggle");
  const html = document.querySelector("html");

  const savedTheme = localStorage.getItem("tema");
  if (savedTheme) {
    html.setAttribute("data-theme", savedTheme);
  }

  toggleBtn.addEventListener("click", function () {
    const current = html.getAttribute("data-theme") === "dark" ? "light" : "dark";
    html.setAttribute("data-theme", current);
    localStorage.setItem("tema", current);
  });
});
