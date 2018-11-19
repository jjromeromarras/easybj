import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from './component/home/home.component';

const routes: Routes = [
    { path: '', component: HomeComponent }
];

export const APP_ROUTER = RouterModule.forRoot(routes);
