var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var H3;
(function (H3) {
    H3.cHTMLAlign = {
        left: {
            align: "left",
            class: "text-left ",
            style: "text-align: left; "
        },
        center: {
            align: "center",
            class: "text-center ",
            style: "text-align: center; "
        },
        right: {
            align: "right",
            class: "text-right ",
            style: "text-align: right; "
        }
    };
})(H3 || (H3 = {}));
var H3;
(function (H3) {
    var FormEvents = (function () {
        function FormEvents() {
            this._arrEvLoad = [];
            this._arrEvResize = [];
        }
        Object.defineProperty(FormEvents.prototype, "eventLoad", {
            set: function (value) {
                this._arrEvLoad.push(value);
                window.addEventListener("load", value);
            },
            enumerable: true,
            configurable: true
        });
        FormEvents.prototype.callEventLoad = function () {
            this._arrEvLoad.forEach(function (funct) {
                funct();
            });
        };
        Object.defineProperty(FormEvents.prototype, "eventResize", {
            set: function (value) {
                this._arrEvResize.push(value);
                window.addEventListener("resize", value);
            },
            enumerable: true,
            configurable: true
        });
        FormEvents.prototype.callEventResize = function () {
            this._arrEvResize.forEach(function (funct) {
                funct();
            });
        };
        FormEvents.prototype.clearEventResize = function () {
            this._arrEvResize.forEach(function (funct) {
                window.removeEventListener("resize", funct);
            });
            this._arrEvResize = [];
        };
        return FormEvents;
    }());
    H3.form = new FormEvents();
})(H3 || (H3 = {}));
var H3;
(function (H3) {
    var InputGeneric = (function () {
        function InputGeneric(strId, objPatt, handler) {
            var _this = this;
            this._booLoad = false;
            this._raw = $();
            this._InnerEvClick = [];
            this._InnerEvFocusIn = [];
            this._InnerEvFocusOut = [];
            this._InnerEvFocus = [];
            this._InnerEvKeUp = [];
            this._InnerEvKeyDown = [];
            this._InnerEvKeyPress = [];
            this._InnerEvChange = [];
            this._evClick = [];
            this._evFocusIn = [];
            this._evFocusOut = [];
            this._evFocus = [];
            this._evKeUp = [];
            this._evKeyDown = [];
            this._evKeyPress = [];
            this._evChange = [];
            var objNew = function () {
                _this._booLoad = true;
                _this._raw = objPatt;
                objBind();
                if (handler != null) {
                    handler(_this._raw);
                }
            };
            var objCall = function () {
                H3.form.eventLoad = function () {
                    _this._booLoad = true;
                    _this._raw = $("#" + strId);
                    if (handler != null) {
                        handler(_this._raw);
                    }
                    objBind();
                };
            };
            var objBind = function () {
                _this._InnerEvClick.forEach(function (funct) {
                    _this._raw.click(funct);
                });
                _this._evClick.forEach(function (funct) {
                    _this._raw.click(funct);
                });
                _this._InnerEvFocusIn.forEach(function (funct) {
                    _this._raw.focusin(funct);
                });
                _this._evFocusIn.forEach(function (funct) {
                    _this._raw.focusin(funct);
                });
                _this._InnerEvFocusOut.forEach(function (funct) {
                    _this._raw.focusout(funct);
                });
                _this._evFocusOut.forEach(function (funct) {
                    _this._raw.focusout(funct);
                });
                _this._InnerEvFocus.forEach(function (funct) {
                    _this._raw.focus(funct);
                });
                _this._evFocus.forEach(function (funct) {
                    _this._raw.focus(funct);
                });
                _this._InnerEvKeUp.forEach(function (funct) {
                    _this._raw.keyup(funct);
                });
                _this._evKeUp.forEach(function (funct) {
                    _this._raw.keyup(funct);
                });
                _this._InnerEvKeyDown.forEach(function (funct) {
                    _this._raw.keydown(funct);
                });
                _this._evKeyDown.forEach(function (funct) {
                    _this._raw.keydown(funct);
                });
                _this._InnerEvKeyPress.forEach(function (funct) {
                    _this._raw.keypress(funct);
                });
                _this._evKeyPress.forEach(function (funct) {
                    _this._raw.keypress(funct);
                });
                _this._InnerEvChange.forEach(function (funct) {
                    _this._raw.change(funct);
                });
                _this._evChange.forEach(function (funct) {
                    _this._raw.change(funct);
                });
            };
            if (strId != null) {
                if (strId.trim() == "") {
                    objNew();
                }
                else {
                    objCall();
                }
            }
            else {
                objNew();
            }
        }
        Object.defineProperty(InputGeneric.prototype, "rawElem", {
            get: function () {
                return this._raw;
            },
            set: function (value) {
                this._raw = value;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(InputGeneric.prototype, "setOnLoad", {
            set: function (value) {
                if (this._booLoad == true) {
                    value();
                }
                else {
                    H3.form.eventLoad = function () {
                        value();
                    };
                }
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(InputGeneric.prototype, "eventClick", {
            set: function (value) {
                this._evClick.push(value);
                if (this._booLoad == true) {
                    this._raw.click(value);
                }
            },
            enumerable: true,
            configurable: true
        });
        InputGeneric.prototype.callEventClick = function () {
            this._raw.click();
        };
        InputGeneric.prototype.clearEventClick = function () {
            var _this = this;
            this._raw.off("click");
            this._evClick = [];
            this._InnerEvClick.forEach(function (funct) {
                _this._raw.click(funct);
            });
        };
        Object.defineProperty(InputGeneric.prototype, "eventFocusIn", {
            set: function (value) {
                this._evFocusIn.push(value);
                if (this._booLoad == true) {
                    this._raw.focusin(value);
                }
            },
            enumerable: true,
            configurable: true
        });
        InputGeneric.prototype.callEventFocusIn = function () {
            this._raw.focusin();
        };
        InputGeneric.prototype.clearEventFocusIn = function () {
            var _this = this;
            this._raw.off("focusin");
            this._evFocusIn = [];
            this._InnerEvFocusIn.forEach(function (funct) {
                _this._raw.focusin(funct);
            });
        };
        Object.defineProperty(InputGeneric.prototype, "eventFocusOut", {
            set: function (value) {
                this._evFocusOut.push(value);
                if (this._booLoad == true) {
                    this._raw.focusout(value);
                }
            },
            enumerable: true,
            configurable: true
        });
        InputGeneric.prototype.callEventFocusOut = function () {
            this._raw.focusout();
        };
        InputGeneric.prototype.clearEventFocusOut = function () {
            var _this = this;
            this._raw.off("focusout");
            this._evFocusOut = [];
            this._InnerEvFocusOut.forEach(function (funct) {
                _this._raw.focusout(funct);
            });
        };
        Object.defineProperty(InputGeneric.prototype, "eventFocus", {
            set: function (value) {
                this._evFocus.push(value);
                if (this._booLoad == true) {
                    this._raw.focus(value);
                }
            },
            enumerable: true,
            configurable: true
        });
        InputGeneric.prototype.callEventFocus = function () {
            this._raw.focus();
        };
        InputGeneric.prototype.clearEventFocus = function () {
            var _this = this;
            this._raw.off("focus");
            this._evFocus = [];
            this._InnerEvFocus.forEach(function (funct) {
                _this._raw.focus(funct);
            });
        };
        Object.defineProperty(InputGeneric.prototype, "eventKeyUp", {
            set: function (value) {
                this._evKeUp.push(value);
                if (this._booLoad == true) {
                    this._raw.keyup(value);
                }
            },
            enumerable: true,
            configurable: true
        });
        InputGeneric.prototype.callEventKeyUp = function () {
            this._raw.keyup();
        };
        InputGeneric.prototype.clearEventKeyUp = function () {
            var _this = this;
            this._raw.off("keyup");
            this._evKeUp = [];
            this._InnerEvKeUp.forEach(function (funct) {
                _this._raw.focus(funct);
            });
        };
        Object.defineProperty(InputGeneric.prototype, "eventKeyDown", {
            set: function (value) {
                this._evKeyDown.push(value);
                if (this._booLoad == true) {
                    this._raw.keydown(value);
                }
            },
            enumerable: true,
            configurable: true
        });
        InputGeneric.prototype.callEventKeyDown = function () {
            this._raw.keydown();
        };
        InputGeneric.prototype.clearEventKeyDown = function () {
            var _this = this;
            this._raw.off("keydown");
            this._evKeyDown = [];
            this._InnerEvKeyDown.forEach(function (funct) {
                _this._raw.focus(funct);
            });
        };
        Object.defineProperty(InputGeneric.prototype, "eventKeyPress", {
            set: function (value) {
                this._evKeyPress.push(value);
                if (this._booLoad == true) {
                    this._raw.keypress(value);
                }
            },
            enumerable: true,
            configurable: true
        });
        InputGeneric.prototype.callEventKeyPress = function () {
            this._raw.keypress();
        };
        InputGeneric.prototype.clearEventKeyPress = function () {
            this._raw.off("keypress");
            this._evKeyPress = [];
        };
        Object.defineProperty(InputGeneric.prototype, "eventChange", {
            set: function (value) {
                this._evChange.push(value);
                if (this._booLoad == true) {
                    this._raw.change(value);
                }
            },
            enumerable: true,
            configurable: true
        });
        InputGeneric.prototype.callEventChange = function () {
            this._raw.change();
        };
        InputGeneric.prototype.clearEventChange = function () {
            this._raw.off("change");
            this._evChange = [];
        };
        return InputGeneric;
    }());
    H3.InputGeneric = InputGeneric;
})(H3 || (H3 = {}));
var H3;
(function (H3) {
    var numCount = 0;
    var Button = (function (_super) {
        __extends(Button, _super);
        function Button(strId) {
            if (strId === void 0) { strId = null; }
            var _this = this;
            var objPatt = $("<button>", {
                type: "button",
                id: "btnRaw" + numCount,
                class: "btn btn-dark"
            }).append($("<i>", { class: "fa fa-circle-thin" }));
            var objHandler = function (me) {
                if (me.children().length == 0) {
                    me.append($("<i>", { class: "fa fa-circle-thin" }));
                }
                if (me.attr("class") == null) {
                    me.attr("class", "btn btn-dark");
                }
                else {
                    if (me.hasClass("btn") == false) {
                        me.addClass("btn");
                    }
                }
            };
            numCount += 1;
            _this = _super.call(this, strId, objPatt, objHandler) || this;
            _this._str_icon = null;
            _this._str_text = null;
            _this._str_class = "btn btn-dark";
            _this._bol_locked = false;
            return _this;
        }
        Object.defineProperty(Button.prototype, "icon", {
            get: function () {
                if (this._str_icon != null) {
                    return this._str_icon.replace(/fa\s+/gi, "");
                }
                else {
                    this.rawElem.find("i").remove();
                    return null;
                }
            },
            set: function (value) {
                var _this = this;
                this.setOnLoad = function () {
                    if (value == null) {
                        _this.rawElem.find("span").removeClass("pl-2");
                        _this.rawElem.find("i").remove();
                        _this._str_icon = null;
                    }
                    else if (value.trim() == "") {
                        _this.rawElem.find("span").removeClass("pl-2");
                        _this.rawElem.find("i").remove();
                        _this._str_icon = null;
                    }
                    else if (value.match(/fa\s+/gi) != null) {
                        _this._str_icon = value;
                        if (_this.rawElem.find("i").length == 0) {
                            _this.rawElem.append($("<i>"));
                        }
                        if (_this.rawElem.find("span").length > 0) {
                            _this.rawElem.find("span").addClass("pl-2");
                        }
                        _this.rawElem.find("i").attr("class", _this._str_icon);
                    }
                    else {
                        _this._str_icon = "fa " + value;
                        if (_this.rawElem.find("i").length == 0) {
                            _this.rawElem.append($("<i>"));
                        }
                        if (_this.rawElem.find("span").length > 0) {
                            _this.rawElem.find("span").addClass("pl-2");
                        }
                        _this.rawElem.find("i").attr("class", _this._str_icon);
                    }
                };
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Button.prototype, "text", {
            get: function () {
                return this._str_text;
            },
            set: function (value) {
                var _this = this;
                this.setOnLoad = function () {
                    if (value == null) {
                        _this.rawElem.find("i").removeClass("pr-2");
                        _this.rawElem.find("span").remove();
                        _this._str_text = null;
                    }
                    else if (value.trim() == "") {
                        _this.rawElem.find("i").removeClass("pr-2");
                        _this.rawElem.find("span").remove();
                        _this._str_text = null;
                    }
                    else {
                        if (_this.rawElem.find("span").length == 0) {
                            _this.rawElem.append($("<span>"));
                        }
                        if (_this.rawElem.find("i").length > 0) {
                            _this.rawElem.find("i").addClass("pr-2");
                        }
                        _this.rawElem.find("span").text(value);
                    }
                };
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Button.prototype, "class", {
            get: function () {
                return this._str_class;
            },
            set: function (value) {
                var _this = this;
                this.setOnLoad = function () {
                    if (value == null) {
                        _this._str_class = null;
                        _this.rawElem.attr("class", "btn btn-dark");
                    }
                    else if (value.trim() == "") {
                        _this._str_class = null;
                        _this.rawElem.attr("class", "btn btn-dark");
                    }
                    else {
                        _this._str_class = value.trim();
                        _this.rawElem.attr("class", _this._str_class);
                    }
                };
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Button.prototype, "locked", {
            get: function () {
                return this._bol_locked;
            },
            set: function (value) {
                var _this = this;
                this.setOnLoad = function () {
                    _this._bol_locked = value;
                    _this.rawElem.prop("disabled", value);
                };
            },
            enumerable: true,
            configurable: true
        });
        return Button;
    }(H3.InputGeneric));
    H3.Button = Button;
})(H3 || (H3 = {}));
var H3;
(function (H3) {
    var numCount = 0;
    var Checkbox = (function (_super) {
        __extends(Checkbox, _super);
        function Checkbox(strId) {
            if (strId === void 0) { strId = null; }
            var _this = this;
            var objPatt = $("<input>", {
                type: "checkbox",
                id: "chkRaw" + numCount
            });
            numCount += 1;
            _this = _super.call(this, strId, objPatt, function (me) {
                var str_class = me.attr("class");
                var str_txt = me.attr("data-text");
                var input = me;
                var icon_true = $("<i>", {
                    "class": "fa fa-check-square",
                    "aria-hidden": true
                });
                var icon_false = $("<i>", {
                    "class": "fa fa-square",
                    "aria-hidden": true
                });
                var label = $("<label>", {
                    for: input.attr("id")
                });
                var container = $("<div>", {
                    class: "w3-chk " + (function () {
                        if (str_class == null) {
                            return "";
                        }
                        else {
                            return str_class;
                        }
                    }())
                });
                label.append(icon_true, icon_false);
                if (str_txt != null) {
                    label.append($("<span>").text(str_txt));
                }
                _this.rawElem.before(container);
                _this.rawElem.remove();
                container.append(input, label);
                _this.rawElem = container;
            }) || this;
            _this._checked = false;
            _this._text = null;
            _this._InnerEvChange.push(function () {
                var value = _this.rawElem.children("input[type=checkbox]").prop("checked");
                _this._checked = value;
            });
            return _this;
        }
        Object.defineProperty(Checkbox.prototype, "checked", {
            get: function () {
                return this._checked;
            },
            set: function (value) {
                var _this = this;
                this._checked = value;
                this.setOnLoad = function () {
                    _this.rawElem.find("input[type=checkbox]").prop("checked", _this._checked);
                };
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Checkbox.prototype, "text", {
            get: function () {
                return this._text;
            },
            set: function (value) {
                var _this = this;
                this._text = value;
                this.setOnLoad = function () {
                    if (_this._text == null) {
                        _this.rawElem.find("label span").remove();
                    }
                    else {
                        if (_this.rawElem.find("label span").length == 0) {
                            _this.rawElem.children("label").append($("<span>").text(_this._text));
                        }
                        else {
                            _this.rawElem.find("label span").text(_this._text);
                        }
                    }
                };
            },
            enumerable: true,
            configurable: true
        });
        return Checkbox;
    }(H3.InputGeneric));
    H3.Checkbox = Checkbox;
})(H3 || (H3 = {}));
var H3;
(function (H3) {
    var numCount = 0;
    var Select = (function (_super) {
        __extends(Select, _super);
        function Select(strId) {
            if (strId === void 0) { strId = null; }
            var _this = this;
            var objPatt = $("<select>", {
                id: "selRaw" + numCount,
                class: "form-control"
            });
            numCount += 1;
            _this = _super.call(this, strId, objPatt) || this;
            return _this;
        }
        Select.prototype.additem = function (text, value) {
            var _this = this;
            var code = { d: value };
            code = JSON.stringify(code);
            code = encodeURI(code);
            code = btoa(code);
            var item = $("<option>", {
                value: code
            }).text(text);
            this.setOnLoad = function () {
                _this.rawElem.append(item);
            };
        };
        Select.prototype.value = function () {
            var objOut;
            var strVal = this.rawElem.val();
            strVal = atob(strVal);
            strVal = decodeURI(strVal);
            objOut = {
                text: this.rawElem.children().filter(":selected").text(),
                value: JSON.parse(strVal).d
            };
            return objOut;
        };
        Select.prototype.clean = function () {
            this.rawElem.empty();
        };
        return Select;
    }(H3.InputGeneric));
    H3.Select = Select;
})(H3 || (H3 = {}));
var H3;
(function (H3) {
    var numTable = 0;
    var Table = (function () {
        function Table(id_dom) {
            if (id_dom === void 0) { id_dom = null; }
            var _this = this;
            this.dtt_is = false;
            this.dtt_display_length = 10;
            this.dtt_paginator = true;
            this.dtt_filter = true;
            this.dtt_sort = true;
            this.str_msg_init = "Por favor realice una b\u00FAsqueda.";
            this.str_msg_none = "No se han encontrado Resultados.";
            this.bol_screen_initial = false;
            this.bol_screen_loading = false;
            this.bol_screen_finish = false;
            this.bol_loading = false;
            this.bol_loaded = false;
            this.arr_headers = [];
            this.arr_data = [];
            this.arr_cell_box = [];
            if (id_dom != null) {
                H3.form.eventLoad = function () {
                    _this.obj_raw = $("#" + id_dom);
                    _this._load();
                };
            }
            else {
                this.bol_loading = false;
                this.bol_loaded = false;
                this.obj_raw = $("<div>", { id: "table_" + numTable });
                numTable += 1;
                this._load();
            }
        }
        Table.prototype._load = function () {
            this.obj_raw.append($("<div>", {
                class: "alert alert-primary mb-0"
            }).html(this.str_msg_init));
            this.bol_loading = true;
            this.bol_loaded = true;
            this.bol_screen_initial = true;
            this.bol_screen_loading = false;
            this.bol_screen_finish = false;
        };
        Object.defineProperty(Table.prototype, "rawElem", {
            get: function () {
                return this.obj_raw;
            },
            set: function (value) {
                this.obj_raw = value;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Table.prototype, "class", {
            get: function () {
                return this.str_class;
            },
            set: function (value) {
                var _this = this;
                this.str_class = value;
                var convert = function () {
                    _this.obj_raw.attr("class", "table-responsive " + _this.str_class);
                };
                if (this.bol_loaded == false) {
                    H3.form.eventLoad = function () {
                        convert();
                    };
                }
                else {
                    convert();
                }
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Table.prototype, "msgInit", {
            get: function () {
                return this.str_msg_init;
            },
            set: function (value) {
                var _this = this;
                this.str_msg_init = value;
                var fn_do = function () {
                    if (_this.bol_screen_initial == true) {
                        _this.obj_raw.children(".alert").html(_this.str_msg_init);
                    }
                };
                if (this.bol_loaded == false) {
                    H3.form.eventLoad = function () {
                        fn_do();
                    };
                }
                else {
                    fn_do();
                }
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Table.prototype, "msgEmpty", {
            get: function () {
                return this.str_msg_none;
            },
            set: function (value) {
                var _this = this;
                this.str_msg_none = value;
                var fn_do = function () {
                    if (_this.bol_screen_initial == true) {
                        _this.obj_raw.children(".alert").html(_this.str_msg_none);
                    }
                };
                if (this.bol_loaded == false) {
                    H3.form.eventLoad = function () {
                        fn_do();
                    };
                }
                else {
                    fn_do();
                }
            },
            enumerable: true,
            configurable: true
        });
        Table.prototype.showInitial = function () {
            var _this = this;
            var fn_do = function () {
                _this.obj_raw.children().fadeOut(250, function () {
                    _this.obj_raw.empty();
                    var div_loading = $("<div>", {
                        class: "alert alert-primary mb-0"
                    }).html(_this.str_msg_init);
                    div_loading.hide();
                    _this.obj_raw.append(div_loading);
                    div_loading.fadeIn(250);
                });
            };
            if (this.bol_loaded == false) {
                H3.form.eventLoad = function () {
                    fn_do();
                };
            }
            else {
                fn_do();
            }
        };
        Object.defineProperty(Table.prototype, "isSelectable", {
            get: function () {
                return this.bol_selectable;
            },
            set: function (value) {
                var _this = this;
                this.bol_selectable = value;
                if (this.bol_screen_finish == false) {
                    return;
                }
                this.obj_raw.find("tbody tr").off("click");
                if (this.eventClick != null) {
                    this.obj_raw.find("tbody tr").click(this.eventClick);
                }
                if (value == true) {
                    this.obj_raw.find("tbody tr").click(function (Me) {
                        _this.obj_raw.find("tbody tr").removeClass("selected");
                        $(Me.currentTarget).addClass("selected");
                        _this.num_value = parseInt($(Me.currentTarget).attr("data-index"));
                    });
                }
            },
            enumerable: true,
            configurable: true
        });
        Table.prototype.showLoading = function () {
            var _this = this;
            var fn_do = function () {
                _this.obj_raw.children().fadeOut(250, function () {
                    _this.obj_raw.empty();
                    var div_loading = $("<div>", { class: "ts-table-loading", style: "display: none;" }).append($("<i>", { class: "fa fa-spinner fa-pulse fa-5x fa-fw" }), $("<h3>", { class: "text-center mt-3" }).text("Cargando..."));
                    _this.obj_raw.append(div_loading);
                    div_loading.fadeIn(250);
                });
            };
            if (this.bol_loaded == false) {
                H3.form.eventLoad = function () {
                    fn_do();
                };
            }
            else {
                fn_do();
            }
        };
        Table.prototype.addHeader = function (text, alignment, width) {
            if (width === void 0) { width = null; }
            this.arr_headers.push({
                content: text,
                align: alignment,
                width: width
            });
        };
        Table.prototype.addCellRow = function (content, alignment, span) {
            var objRow = {
                content: content,
                align: alignment
            };
            if (span != null) {
                objRow.span = span;
            }
            this.arr_cell_box.push(objRow);
        };
        Table.prototype.makeRow = function (value) {
            if (value === void 0) { value = null; }
            var arr_insert = [];
            this.arr_cell_box.forEach(function (xitem) {
                var xobj = {
                    content: xitem.content,
                    align: xitem.align
                };
                if (xitem.width != null) {
                    xobj.width = xitem.width;
                }
                if (xitem.span != null) {
                    xobj.span = xitem.span;
                }
                arr_insert.push(xobj);
            });
            this.arr_data.push({
                value: value,
                arr_cell: arr_insert
            });
            this.arr_cell_box = [];
        };
        Table.prototype.makeTable = function (callback) {
            var _this = this;
            if (callback === void 0) { callback = null; }
            var bol_dtt = this.dtt_is;
            var fn_do = function () {
                if (_this.arr_data.length == 0) {
                    _this.bol_screen_initial = true;
                    _this.bol_screen_loading = false;
                    _this.bol_screen_finish = false;
                    setTimeout(function () {
                        _this.obj_raw.children().fadeOut(250, function () {
                            _this.obj_raw.empty();
                            _this.obj_raw.append($("<div>", {
                                class: "alert alert-danger mb-0"
                            }).html(_this.str_msg_none));
                            if (callback != null) {
                                callback();
                            }
                        });
                    }, 300);
                    _this.arr_cell_box = [];
                    _this.arr_data = [];
                    _this.arr_headers = [];
                    return;
                }
                var obj_ts_table = $("<table>", { class: "w-100 table table-striped" });
                obj_ts_table.append($("<thead>").append($("<tr>")), $("<tbody>"));
                _this.arr_headers.forEach(function (xitem) {
                    var xth = $("<th>", {
                        class: xitem.align.class
                    }).append(xitem.content);
                    if (xitem.width != null) {
                        xth.css({ "min-width": xitem.width });
                    }
                    obj_ts_table.find("tr").append(xth);
                });
                _this.arr_data.forEach(function (xitem, xi) {
                    var row_val = { d: xitem.value };
                    row_val = JSON.stringify(row_val);
                    row_val = encodeURI(row_val);
                    row_val = btoa(row_val);
                    var xrow = $("<tr>", {
                        "data-index": xi,
                        "data-value": row_val
                    });
                    xitem.arr_cell.forEach(function (xcell) {
                        var xtd = $("<td>", {
                            class: xcell.align.class
                        }).append(xcell.content);
                        if (xcell.span != null) {
                            bol_dtt = false;
                            if (xcell.span.col != null) {
                                xtd.attr("colspan", xcell.span.col);
                            }
                            if (xcell.span.row != null) {
                                xtd.attr("rowspan", xcell.span.row);
                            }
                        }
                        xrow.append(xtd);
                    });
                    obj_ts_table.append(xrow);
                });
                if (_this.bol_selectable == true) {
                    obj_ts_table.find("tbody tr").click(function (Me) {
                        obj_ts_table.find("tbody tr").removeClass("selected");
                        $(Me.currentTarget).addClass("selected");
                        _this.num_value = parseInt($(Me.currentTarget).attr("data-index"));
                    });
                    obj_ts_table.find("tbody tr input").focusout(function (Me) {
                        obj_ts_table.find("tbody tr").removeClass("selected");
                        _this.num_value = null;
                    });
                    obj_ts_table.find("tbody tr input").focusin(function (Me) {
                        obj_ts_table.find("tbody tr").removeClass("selected");
                        var tr = $(Me.currentTarget).parents("tr").eq(0);
                        tr.addClass("selected");
                        _this.num_value = parseInt(tr.attr("data-index"));
                    });
                }
                if (_this.clickRow != null) {
                    obj_ts_table.find("tbody tr").click(_this.clickRow);
                }
                _this.num_value = null;
                _this.arr_cell_box = [];
                _this.arr_data = [];
                _this.arr_headers = [];
                var fn_make_dtt = function () {
                    if (bol_dtt == true) {
                        var obj_dtt = _this.obj_raw.children("table").DataTable({
                            "iDisplayLength": _this.dtt_display_length,
                            "info": _this.dtt_paginator,
                            "bPaginate": _this.dtt_paginator,
                            "bFilter": _this.dtt_filter,
                            "bSort": _this.dtt_sort,
                            "language": {
                                "lengthMenu": "Mostrar: _MENU_",
                                "zeroRecords": "No hay concidencias",
                                "info": "Mostrando Página _PAGE_ de _PAGES_",
                                "infoEmpty": "No hay concidencias",
                                "infoFiltered": "(Se buscó en _MAX_ registros )",
                                "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                                "paginate": {
                                    "previous": "Anterior",
                                    "next": "Siguiente"
                                }
                            }
                        });
                        obj_dtt.on("preDraw", function () {
                            obj_ts_table.find("tbody tr").removeClass("selected");
                        });
                        obj_dtt.on("draw", function () {
                            obj_ts_table.find("tbody tr[data-index=\"" + _this.num_value + "\"]").addClass("selected");
                        });
                        if (_this.dtt_paginator == true) {
                        }
                        else {
                            _this.obj_raw.find("table").parent().addClass("mb-3");
                        }
                        _this.obj_raw.find(".dataTables_filter").parent().attr({ "class": "col-12 col-sm-9" });
                        _this.obj_raw.find(".dataTables_length").parent().attr({ "class": "col-12 col-sm-3" });
                        _this.obj_raw.find("table").parent().addClass("table-responsive");
                        _this.bol_screen_initial = false;
                        _this.bol_screen_loading = false;
                        _this.bol_screen_finish = true;
                    }
                };
                setTimeout(function () {
                    obj_ts_table.css({ display: "none" });
                    _this.obj_raw.children().fadeOut(240);
                    setTimeout(function () {
                        _this.obj_raw.children().remove();
                        _this.obj_raw.append(obj_ts_table);
                        fn_make_dtt();
                        obj_ts_table.fadeIn(250, function () {
                            if (callback != null) {
                                callback();
                            }
                        });
                    }, 250);
                }, 300);
            };
            if (this.bol_loaded == false) {
                H3.form.eventLoad = function () {
                    fn_do();
                };
            }
            else {
                fn_do();
            }
        };
        Table.prototype.setDataTable = function (set, display_length, paginator, filter, sort) {
            if (set === void 0) { set = true; }
            if (display_length === void 0) { display_length = 10; }
            if (paginator === void 0) { paginator = true; }
            if (filter === void 0) { filter = true; }
            if (sort === void 0) { sort = true; }
            this.dtt_is = set;
            this.dtt_display_length = display_length;
            this.dtt_paginator = paginator;
            this.dtt_filter = filter;
            this.dtt_sort = sort;
        };
        Object.defineProperty(Table.prototype, "eventClick", {
            get: function () {
                return this.clickRow;
            },
            set: function (value) {
                var _this = this;
                this.clickRow = value;
                var fn_do = function () {
                    if (_this.bol_screen_finish == false) {
                        return;
                    }
                    _this.obj_raw.off("click");
                    if (value != null) {
                        _this.obj_raw.find("tbody tr").click(_this.clickRow());
                    }
                };
                if (this.bol_loaded == false) {
                    this.obj_raw.on("DOMNodeInserted", function () {
                        fn_do();
                    });
                }
                else {
                    fn_do();
                }
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Table.prototype, "index", {
            get: function () {
                return this.num_value;
            },
            set: function (val) {
                if (this.obj_raw.find("tbody tr[data-index=" + val + "]").length == 0) {
                    return;
                }
                this.obj_raw.find("tbody tr.selected").removeClass("selected");
                this.obj_raw.find("tbody tr[data-index=" + val + "]").addClass("selected");
                this.num_value = val;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Table.prototype, "value", {
            get: function () {
                if (this.obj_raw.find("tbody > .selected").length == 0) {
                    return null;
                }
                var obj_value = this.obj_raw.find("tbody > .selected").attr("data-value");
                obj_value = atob(obj_value);
                obj_value = decodeURI(obj_value);
                obj_value = JSON.parse(obj_value).d;
                return obj_value;
            },
            set: function (val) {
                if (this.obj_raw.find("tbody > .selected").length == 0) {
                    return;
                }
                var str_val = JSON.stringify({ d: val });
                str_val = encodeURI(str_val);
                str_val = btoa(str_val);
                this.obj_raw.find("tbody > .selected").attr("data-value", str_val);
            },
            enumerable: true,
            configurable: true
        });
        return Table;
    }());
    H3.Table = Table;
})(H3 || (H3 = {}));
var H3;
(function (H3) {
    var numCount = 0;
    var Textbox = (function (_super) {
        __extends(Textbox, _super);
        function Textbox(strId) {
            if (strId === void 0) { strId = null; }
            var _this = this;
            var objPatt = $("<input>", {
                type: "text",
                id: "txtRaw" + numCount,
                class: "form-control"
            });
            numCount += 1;
            _this = _super.call(this, strId, objPatt) || this;
            _this._booDatePicker = false;
            return _this;
        }
        Object.defineProperty(Textbox.prototype, "datePicker", {
            get: function () {
                return this._booDatePicker;
            },
            set: function (value) {
                var _this = this;
                var convToDatePicker = function () {
                    var parent = _this.rawElem.parent();
                    var addon = $("<span>", {
                        class: "btn btn-primary input-group-addon"
                    }).append($("<i>", { class: "fa fa-calendar" }));
                    parent.remove("input[type=text]");
                    parent.append($("<div>", {
                        class: "input-group date"
                    }).append(_this.rawElem, addon));
                    _this.rawElem.val(moment().format("DD/MM/YYYY"));
                    _this.rawElem.parent().datepicker({
                        format: "dd/mm/yyyy",
                        language: "es",
                        autoclose: true
                    });
                };
                var convToTextbox = function () {
                    var parent = _this.rawElem.parent().parent();
                    parent.datepicker("remove");
                    parent.children("div.input-group.date").remove();
                    parent.append(_this.rawElem);
                };
                var covAction = function () {
                    if (value == true) {
                        if (_this._booTimePicker == true) {
                            _this.timePicker = false;
                        }
                        convToDatePicker();
                    }
                    else {
                        convToTextbox();
                    }
                };
                if (this._booDatePicker == value) {
                    return;
                }
                else {
                    this._booDatePicker = value;
                }
                this.setOnLoad = covAction;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Textbox.prototype, "timePicker", {
            get: function () {
                return this._booTimePicker;
            },
            set: function (value) {
                var _this = this;
                var convToTimePicker = function () {
                    var parent = _this.rawElem.parent();
                    var addon = $("<span>", {
                        class: "btn btn-primary input-group-addon"
                    }).append($("<i>", { class: "fa fa-clock-o" }));
                    parent.remove("input[type=text]");
                    parent.append($("<div>", {
                        class: "input-group clockPicker"
                    }).append(_this.rawElem, addon));
                    _this.rawElem.val(moment().format("hh:mm"));
                    _this.rawElem.parent().clockpicker({
                        donetext: 'Hecho'
                    });
                };
                var convToTextbox = function () {
                    var parent = _this.rawElem.parent().parent();
                    parent.clockpicker("remove");
                    parent.find("div.input-group.clockPicker").remove();
                    parent.append(_this.rawElem);
                };
                var covAction = function () {
                    if (value == true) {
                        if (_this._booDatePicker == true) {
                            _this.datePicker = false;
                        }
                        convToTimePicker();
                    }
                    else {
                        convToTextbox();
                    }
                };
                if (this._booTimePicker == value) {
                    return;
                }
                else {
                    this._booTimePicker = value;
                }
                this.setOnLoad = covAction;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Textbox.prototype, "value", {
            get: function () {
                return this.rawElem.val();
            },
            set: function (val) {
                this.rawElem.val(val);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Textbox.prototype, "locked", {
            get: function () {
                return this.rawElem.prop("readonly");
            },
            set: function (value) {
                var _this = this;
                this.setOnLoad = function () {
                    _this.rawElem.prop("readonly", value);
                };
            },
            enumerable: true,
            configurable: true
        });
        return Textbox;
    }(H3.InputGeneric));
    H3.Textbox = Textbox;
})(H3 || (H3 = {}));
var U3;
(function (U3) {
    var Ajax = (function () {
        function Ajax() {
            this.str_type = "POST";
            this.str_contentType = "application/json;  charset=utf-8";
            this.str_dataType = "json";
            this.str_url_root = location.href + "/";
            this.str_url_user = null;
        }
        Object.defineProperty(Ajax.prototype, "url", {
            get: function () {
                return this.str_url_root;
            },
            set: function (value) {
                this.str_url_root = value;
                if (value.match(/\/$/gi) == null) {
                    this.str_url_root += "/";
                }
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Ajax.prototype, "functName", {
            get: function () {
                return this.str_url_user;
            },
            set: function (value) {
                this.str_url_user = value;
                if (value.match(/^\//gi) == null) {
                    this.str_url_user = value.replace(/^\//gi, "");
                }
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Ajax.prototype, "success", {
            get: function () {
                return this.fn_success;
            },
            set: function (fn) {
                this.fn_success = fn;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Ajax.prototype, "error", {
            get: function () {
                return this.fn_success;
            },
            set: function (fn) {
                this.fn_error = fn;
            },
            enumerable: true,
            configurable: true
        });
        Ajax.prototype.requestNow = function (parameters, callback) {
            var obj_options = {};
            obj_options.type = this.str_type;
            obj_options.url = "" + this.str_url_root + this.str_url_user;
            obj_options.contentType = this.str_contentType;
            obj_options.dataType = this.str_dataType;
            obj_options.success = this.fn_success;
            obj_options.error = this.fn_error;
            if (parameters != null) {
                obj_options.data = JSON.stringify(parameters);
            }
            if (callback != null) {
                obj_options.complete = callback;
            }
            this.obj_promise = $.ajax(obj_options);
        };
        Object.defineProperty(Ajax.prototype, "promise", {
            get: function () {
                return this.obj_promise;
            },
            set: function (value) {
                this.obj_promise = value;
            },
            enumerable: true,
            configurable: true
        });
        return Ajax;
    }());
    U3.Ajax = Ajax;
})(U3 || (U3 = {}));
var U3;
(function (U3) {
    var CONV;
    (function (CONV) {
        CONV.isNum = function (value) {
            var xEval = ("" + value).match(/^-?[0-9]+((\.|,)[0-9]+)?$/gi);
            if (xEval == null) {
                return false;
            }
            return true;
        };
        CONV.formatNum = function (num, cantDec) {
            num = "" + num;
            num = num.trim();
            num = num.replace(/,/gi, ".");
            num = parseFloat(num);
            if (CONV.isNum(num) == false) {
                return "-";
            }
            if (num == null) {
                return "-";
            }
            var arrRaw = ("" + parseFloat("" + num)).split(".");
            var strOut = "";
            var arrEnt = ("" + arrRaw[0]).split("");
            for (var i = arrEnt.length - 1; i >= 0; i--) {
                strOut = "" + arrEnt[i] + strOut;
                var reverse = (arrEnt.length) - i;
                if ((i != 0) && (i != arrEnt.length - 1) && ((reverse % 3) == 0)) {
                    strOut = "." + strOut;
                }
            }
            if (cantDec == 0) {
                return strOut;
            }
            if (arrRaw[1] == null) {
                arrRaw.push("");
            }
            if (cantDec == null) {
                if (arrRaw[1].length > 0) {
                    strOut = strOut + ",";
                    strOut = "" + strOut + arrRaw[1];
                }
                return strOut;
            }
            if (cantDec >= arrRaw[1].length) {
                strOut = strOut + ",";
                for (var i = arrRaw[1].length; i < cantDec; i++) {
                    strOut = strOut + "0";
                }
            }
            else {
                strOut = strOut + ",";
                var arrDec = arrRaw[1].split("");
                arrDec.forEach(function (item, i) {
                    if ((i + 1) > cantDec) {
                        return;
                    }
                    strOut = "" + strOut + item;
                });
            }
            return strOut;
        };
    })(CONV = U3.CONV || (U3.CONV = {}));
})(U3 || (U3 = {}));
