﻿/*
 Highcharts JS v5.0.7 (2017-01-17)
 Exporting module
 (c) 2010-2016 Torstein Honsi
 License: www.highcharts.com/license
*/
(function (h) { "object" === typeof module && module.exports ? module.exports = h : h(Highcharts) })(function (h) {
    (function (f) {
        var h = f.defaultOptions, n = f.doc, A = f.Chart, u = f.addEvent, F = f.removeEvent, D = f.fireEvent, q = f.createElement, B = f.discardElement, v = f.css, p = f.merge, C = f.pick, k = f.each, r = f.extend, G = f.isTouchDevice, E = f.win, H = f.Renderer.prototype.symbols; r(h.lang, {
            printChart: "Print chart", downloadPNG: "Download PNG image", downloadJPEG: "Download JPEG image", downloadPDF: "Download PDF document", downloadSVG: "Download SVG vector image",
            contextButtonTitle: "Chart context menu"
        }); h.navigation = { buttonOptions: { theme: {}, symbolSize: 14, symbolX: 12.5, symbolY: 10.5, align: "right", buttonSpacing: 3, height: 22, verticalAlign: "top", width: 24 } }; p(!0, h.navigation, {
            menuStyle: { border: "1px solid #999999", background: "#ffffff", padding: "5px 0" }, menuItemStyle: { padding: "0.5em 1em", background: "none", color: "#333333", fontSize: G ? "14px" : "11px", transition: "background 250ms, color 250ms" }, menuItemHoverStyle: { background: "#335cad", color: "#ffffff" }, buttonOptions: {
                symbolFill: "#666666",
                symbolStroke: "#666666", symbolStrokeWidth: 3, theme: { fill: "#ffffff", stroke: "none", padding: 5 }
            }
        }); h.exporting = {
            type: "image/png", url: "https://export.highcharts.com/", printMaxWidth: 780, scale: 2, buttons: {
                contextButton: {
                    className: "highcharts-contextbutton", menuClassName: "highcharts-contextmenu", symbol: "menu", _titleKey: "contextButtonTitle", menuItems: [{ textKey: "printChart", onclick: function () { this.print() } }, { separator: !0 }, { textKey: "downloadPNG", onclick: function () { this.exportChart() } }, { textKey: "downloadJPEG", onclick: function () { this.exportChart({ type: "image/jpeg" }) } },
                    { textKey: "downloadPDF", onclick: function () { this.exportChart({ type: "application/pdf" }) } }, { textKey: "downloadSVG", onclick: function () { this.exportChart({ type: "image/svg+xml" }) } }]
                }
            }
        }; f.post = function (a, c, e) { var b; a = q("form", p({ method: "post", action: a, enctype: "multipart/form-data" }, e), { display: "none" }, n.body); for (b in c) q("input", { type: "hidden", name: b, value: c[b] }, null, a); a.submit(); B(a) }; r(A.prototype, {
            sanitizeSVG: function (a, c) {
                if (c && c.exporting && c.exporting.allowHTML) {
                    var e = a.match(/<\/svg>(.*?$)/); e && (e =
                    '\x3cforeignObject x\x3d"0" y\x3d"0" width\x3d"' + c.chart.width + '" height\x3d"' + c.chart.height + '"\x3e\x3cbody xmlns\x3d"http://www.w3.org/1999/xhtml"\x3e' + e[1] + "\x3c/body\x3e\x3c/foreignObject\x3e", a = a.replace("\x3c/svg\x3e", e + "\x3c/svg\x3e"))
                } a = a.replace(/zIndex="[^"]+"/g, "").replace(/isShadow="[^"]+"/g, "").replace(/symbolName="[^"]+"/g, "").replace(/jQuery[0-9]+="[^"]+"/g, "").replace(/url\(("|&quot;)(\S+)("|&quot;)\)/g, "url($2)").replace(/url\([^#]+#/g, "url(#").replace(/<svg /, '\x3csvg xmlns:xlink\x3d"http://www.w3.org/1999/xlink" ').replace(/ (NS[0-9]+\:)?href=/g,
                " xlink:href\x3d").replace(/\n/, " ").replace(/<\/svg>.*?$/, "\x3c/svg\x3e").replace(/(fill|stroke)="rgba\(([ 0-9]+,[ 0-9]+,[ 0-9]+),([ 0-9\.]+)\)"/g, '$1\x3d"rgb($2)" $1-opacity\x3d"$3"').replace(/&nbsp;/g, "\u00a0").replace(/&shy;/g, "\u00ad"); return a = a.replace(/<IMG /g, "\x3cimage ").replace(/<(\/?)TITLE>/g, "\x3c$1title\x3e").replace(/height=([^" ]+)/g, 'height\x3d"$1"').replace(/width=([^" ]+)/g, 'width\x3d"$1"').replace(/hc-svg-href="([^"]+)">/g, 'xlink:href\x3d"$1"/\x3e').replace(/ id=([^" >]+)/g, ' id\x3d"$1"').replace(/class=([^" >]+)/g,
                'class\x3d"$1"').replace(/ transform /g, " ").replace(/:(path|rect)/g, "$1").replace(/style="([^"]+)"/g, function (a) { return a.toLowerCase() })
            }, getChartHTML: function () { return this.container.innerHTML }, getSVG: function (a) {
                var c, e, b, w, m, g = p(this.options, a); n.createElementNS || (n.createElementNS = function (a, c) { return n.createElement(c) }); e = q("div", null, { position: "absolute", top: "-9999em", width: this.chartWidth + "px", height: this.chartHeight + "px" }, n.body); b = this.renderTo.style.width; m = this.renderTo.style.height;
                b = g.exporting.sourceWidth || g.chart.width || /px$/.test(b) && parseInt(b, 10) || 600; m = g.exporting.sourceHeight || g.chart.height || /px$/.test(m) && parseInt(m, 10) || 400; r(g.chart, { animation: !1, renderTo: e, forExport: !0, renderer: "SVGRenderer", width: b, height: m }); g.exporting.enabled = !1; delete g.data; g.series = []; k(this.series, function (a) { w = p(a.userOptions, { animation: !1, enableMouseTracking: !1, showCheckbox: !1, visible: a.visible }); w.isInternal || g.series.push(w) }); k(this.axes, function (a) { a.userOptions.internalKey = f.uniqueKey() });
                c = new f.Chart(g, this.callback); a && k(["xAxis", "yAxis", "series"], function (b) { var d = {}; a[b] && (d[b] = a[b], c.update(d)) }); k(this.axes, function (a) { var b = f.find(c.axes, function (b) { return b.options.internalKey === a.userOptions.internalKey }), d = a.getExtremes(), e = d.userMin, d = d.userMax; !b || void 0 === e && void 0 === d || b.setExtremes(e, d, !0, !1) }); b = c.getChartHTML(); b = this.sanitizeSVG(b, g); g = null; c.destroy(); B(e); return b
            }, getSVGForExport: function (a, c) {
                var e = this.options.exporting; return this.getSVG(p({ chart: { borderRadius: 0 } },
                e.chartOptions, c, { exporting: { sourceWidth: a && a.sourceWidth || e.sourceWidth, sourceHeight: a && a.sourceHeight || e.sourceHeight } }))
            }, exportChart: function (a, c) { c = this.getSVGForExport(a, c); a = p(this.options.exporting, a); f.post(a.url, { filename: a.filename || "chart", type: a.type, width: a.width || 0, scale: a.scale, svg: c }, a.formAttributes) }, print: function () {
                var a = this, c = a.container, e = [], b = c.parentNode, f = n.body, m = f.childNodes, g = a.options.exporting.printMaxWidth, d, t; if (!a.isPrinting) {
                    a.isPrinting = !0; a.pointer.reset(null,
                    0); D(a, "beforePrint"); if (t = g && a.chartWidth > g) d = [a.options.chart.width, void 0, !1], a.setSize(g, void 0, !1); k(m, function (a, b) { 1 === a.nodeType && (e[b] = a.style.display, a.style.display = "none") }); f.appendChild(c); E.focus(); E.print(); setTimeout(function () { b.appendChild(c); k(m, function (a, b) { 1 === a.nodeType && (a.style.display = e[b]) }); a.isPrinting = !1; t && a.setSize.apply(a, d); D(a, "afterPrint") }, 1E3)
                }
            }, contextMenu: function (a, c, e, b, f, m, g) {
                var d = this, t = d.options.navigation, w = d.chartWidth, h = d.chartHeight, p = "cache-" + a,
                l = d[p], x = Math.max(f, m), y, z; l || (d[p] = l = q("div", { className: a }, { position: "absolute", zIndex: 1E3, padding: x + "px" }, d.container), y = q("div", { className: "highcharts-menu" }, null, l), v(y, r({ MozBoxShadow: "3px 3px 10px #888", WebkitBoxShadow: "3px 3px 10px #888", boxShadow: "3px 3px 10px #888" }, t.menuStyle)), z = function () { v(l, { display: "none" }); g && g.setState(0); d.openMenu = !1 }, u(l, "mouseleave", function () { l.hideTimer = setTimeout(z, 500) }), u(l, "mouseenter", function () { clearTimeout(l.hideTimer) }), p = u(n, "mouseup", function (b) {
                    d.pointer.inClass(b.target,
                    a) || z()
                }), u(d, "destroy", p), k(c, function (a) { if (a) { var b; a.separator ? b = q("hr", null, null, y) : (b = q("div", { className: "highcharts-menu-item", onclick: function (b) { b && b.stopPropagation(); z(); a.onclick && a.onclick.apply(d, arguments) }, innerHTML: a.text || d.options.lang[a.textKey] }, null, y), b.onmouseover = function () { v(this, t.menuItemHoverStyle) }, b.onmouseout = function () { v(this, t.menuItemStyle) }, v(b, r({ cursor: "pointer" }, t.menuItemStyle))); d.exportDivElements.push(b) } }), d.exportDivElements.push(y, l), d.exportMenuWidth =
                l.offsetWidth, d.exportMenuHeight = l.offsetHeight); c = { display: "block" }; e + d.exportMenuWidth > w ? c.right = w - e - f - x + "px" : c.left = e - x + "px"; b + m + d.exportMenuHeight > h && "top" !== g.alignOptions.verticalAlign ? c.bottom = h - b - x + "px" : c.top = b + m - x + "px"; v(l, c); d.openMenu = !0
            }, addButton: function (a) {
                var c = this, e = c.renderer, b = p(c.options.navigation.buttonOptions, a), f = b.onclick, m = b.menuItems, g, d, h = b.symbolSize || 12; c.btnCount || (c.btnCount = 0); c.exportDivElements || (c.exportDivElements = [], c.exportSVGElements = []); if (!1 !== b.enabled) {
                    var k =
                    b.theme, n = k.states, q = n && n.hover, n = n && n.select, l; delete k.states; f ? l = function (a) { a.stopPropagation(); f.call(c, a) } : m && (l = function () { c.contextMenu(d.menuClassName, m, d.translateX, d.translateY, d.width, d.height, d); d.setState(2) }); b.text && b.symbol ? k.paddingLeft = C(k.paddingLeft, 25) : b.text || r(k, { width: b.width, height: b.height, padding: 0 }); d = e.button(b.text, 0, 0, l, k, q, n).addClass(a.className).attr({ "stroke-linecap": "round", title: c.options.lang[b._titleKey], zIndex: 3 }); d.menuClassName = a.menuClassName || "highcharts-menu-" +
                    c.btnCount++; b.symbol && (g = e.symbol(b.symbol, b.symbolX - h / 2, b.symbolY - h / 2, h, h).addClass("highcharts-button-symbol").attr({ zIndex: 1 }).add(d), g.attr({ stroke: b.symbolStroke, fill: b.symbolFill, "stroke-width": b.symbolStrokeWidth || 1 })); d.add().align(r(b, { width: d.width, x: C(b.x, c.buttonOffset) }), !0, "spacingBox"); c.buttonOffset += (d.width + b.buttonSpacing) * ("right" === b.align ? -1 : 1); c.exportSVGElements.push(d, g)
                }
            }, destroyExport: function (a) {
                var c = a ? a.target : this; a = c.exportSVGElements; var e = c.exportDivElements; a &&
                (k(a, function (a, e) { a && (a.onclick = a.ontouchstart = null, c.exportSVGElements[e] = a.destroy()) }), a.length = 0); e && (k(e, function (a, e) { clearTimeout(a.hideTimer); F(a, "mouseleave"); c.exportDivElements[e] = a.onmouseout = a.onmouseover = a.ontouchstart = a.onclick = null; B(a) }), e.length = 0)
            }
        }); H.menu = function (a, c, e, b) { return ["M", a, c + 2.5, "L", a + e, c + 2.5, "M", a, c + b / 2 + .5, "L", a + e, c + b / 2 + .5, "M", a, c + b - 1.5, "L", a + e, c + b - 1.5] }; A.prototype.renderExporting = function () {
            var a, c = this.options.exporting, e = c.buttons, b = this.isDirtyExporting || !this.exportSVGElements;
            this.buttonOffset = 0; this.isDirtyExporting && this.destroyExport(); if (b && !1 !== c.enabled) { for (a in e) this.addButton(e[a]); this.isDirtyExporting = !1 } u(this, "destroy", this.destroyExport)
        }; A.prototype.callbacks.push(function (a) { a.renderExporting(); u(a, "redraw", a.renderExporting); k(["exporting", "navigation"], function (c) { a[c] = { update: function (e, b) { a.isDirtyExporting = !0; p(!0, a.options[c], e); C(b, !0) && a.redraw() } } }) })
    })(h)
});
