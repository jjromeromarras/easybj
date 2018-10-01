import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { LoginComponent } from './component/login/login.component';
import { HomeComponent } from './component/home/home.component';

const routes: Routes = [
    { path: '', component: LoginComponent },
    { path: 'easyb', component: HomeComponent },
];

export const APP_ROUTER = RouterModule.forRoot(routes);
