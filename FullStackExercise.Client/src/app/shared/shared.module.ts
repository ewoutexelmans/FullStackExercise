import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { LayoutComponent } from './layout/layout.component';
import { RouterModule } from '@angular/router';
import { SpinnerComponent } from './spinner/spinner.component';

@NgModule({
  declarations: [HeaderComponent, LayoutComponent, SpinnerComponent],
  imports: [CommonModule, RouterModule],
  exports: [SpinnerComponent]
})
export class SharedModule {}
