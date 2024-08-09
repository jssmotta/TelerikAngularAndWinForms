import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { WinChartComponent } from "./win-chart/win-chart.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, WinChartComponent, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'winforms-and-angular';
}



