import { NgModule } from "@angular/core";
import { StartupComponent } from "./startup.component";
import {BrowserModule} from "@angular/platform-browser"

@NgModule({
    declarations:[StartupComponent],
    imports:[
        BrowserModule
    ],
    bootstrap: [StartupComponent]
})
export class StartupModule {}
