import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { WinChartComponent } from "../win-chart/win-chart.component";

@Component({
  selector: 'app-graph-control',
  standalone: true,
  imports: [CommonModule, WinChartComponent, RouterOutlet],
  templateUrl: './graph-control.component.html',
  styleUrl: './graph-control.component.css'
})

export class GraphControlComponent {
  title = 'winforms-and-angular';
}

