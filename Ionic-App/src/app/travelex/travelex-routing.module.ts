import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TravelexPage } from './travelex.page';

const routes: Routes = [
  {
    path: '',
    component: TravelexPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TravelexPageRoutingModule {}
