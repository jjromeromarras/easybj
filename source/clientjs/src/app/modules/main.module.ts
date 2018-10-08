import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { APP_ROUTER } from '../app.routes';
import { FormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { AgmCoreModule } from '@agm/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Config } from '../services/config.service';
import { EasyBComponent } from '../component/easyb/easyb.component';
import { HomeComponent } from '../component/home/home.component';
import { ViewFieldComponent } from '../component/interfaz/viewfield/viewfield.component';
import { ToolbarComponent } from '../component/toolbar/toolbar.component';
import { TreeComponent } from '../component/tree/tree.component';
import { ToolbarGroupComponent } from '../component/toolbar/toolbargroup.component';
import { WorkAreaComponent } from '../component/workarea/workarea.component';
import { ApplicationComponent } from '../component/applications/application.component';
import { ViewFieldTextComponent } from '../component/interfaz/viewfield/controls/viewfieldtextarea/viewfieldtext.component';
import { ViewFieldTextAreaComponent } from '../component/interfaz/viewfield/controls/viewfieldtextarea/viewfieldtextarea.component';
import { ViewFieldSpinComponent } from '../component/interfaz/viewfield/controls/viewfieldspin/viewfieldspin.component';
import { ViewFieldSelectBoxComponent } from '../component/interfaz/viewfield/controls/viewfieldselectbox/viewfieldselectbox.component';
import { ViewFieldDateTimeComponent } from '../component/interfaz/viewfield/controls/viewfielddatetime/viewfielddatetime.component';
import { ViewFieldBooleanComponent } from '../component/interfaz/viewfield/controls/viewfieldboolean/viewfieldboolean.component';
import { ViewPanelComponent } from '../component/interfaz/viewpanel/viewpanel.component';
import { ViewPageControlComponent } from '../component/interfaz/viewpagecontrol/viewpagecontrol.component';
import { EntityEditorComponent } from '../component/interfaz/entityeditor/entityeditor.component';
import { ErrorHandlerService } from '../services/errorHandler/errorHandler.service';
import { BroadcasterService } from 'ng-broadcaster';
import { LoginComponent } from '../component/login/login.component';
import { LanguagesComponent } from '../component/languages/languages.component';
import { ViewGridComponent } from '../component/interfaz/viewgrid/viewgrid.component';
import { DialogComponent } from '../component/interfaz/dialog/dialog.component';
import { ViewGroupsComponent } from '../component/viewgroups/viewgroups.component';


@NgModule({
  declarations: [
    EasyBComponent,
    HomeComponent,
    ToolbarComponent,
    TreeComponent,
    ToolbarGroupComponent,
    WorkAreaComponent,
    ApplicationComponent,
    ViewFieldComponent,
    ViewFieldTextComponent,
    ViewFieldTextAreaComponent,
    ViewFieldSpinComponent,
    ViewFieldSelectBoxComponent,
    ViewFieldDateTimeComponent,
    ViewFieldBooleanComponent,
    ViewPanelComponent,
    ViewPageControlComponent,
    EntityEditorComponent,
    ApplicationComponent,
    ViewGridComponent,
    LanguagesComponent,
    LoginComponent,
    DialogComponent,
    ViewGroupsComponent
  ],
  imports: [
    BrowserModule, DevExtremeModule, BrowserAnimationsModule, HttpModule, AgmCoreModule,
    APP_ROUTER, FormsModule
  ],
  providers: [Config, ErrorHandlerService, BroadcasterService],
  bootstrap: [EasyBComponent]
})
export class MainModule { }
