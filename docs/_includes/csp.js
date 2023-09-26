const cspHeader = "frame-ancestors 'none';";
document.addEventListener("DOMContentLoaded", function () {
  const meta = document.createElement("meta");
  meta.httpEquiv = "Content-Security-Policy";
  meta.content = cspHeader;
  document.head.appendChild(meta);
});