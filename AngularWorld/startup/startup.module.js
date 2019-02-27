"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
var core_1 = require("@angular/core");
var startup_component_1 = require("./startup.component");
var platform_browser_1 = require("@angular/platform-browser");
var StartupModule = /** @class */ (function () {
    function StartupModule() {
    }
    StartupModule = __decorate([
        core_1.NgModule({
            declarations: [startup_component_1.StartupComponent],
            imports: [
                platform_browser_1.BrowserModule
            ],
            bootstrap: [startup_component_1.StartupComponent]
        })
    ], StartupModule);
    return StartupModule;
}());
exports.StartupModule = StartupModule;
