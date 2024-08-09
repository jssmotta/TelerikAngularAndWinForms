import { Component } from '@angular/core';
import { ChartsModule, LegendLabelsContentArgs, SeriesClickEvent, SeriesType } from "@progress/kendo-angular-charts";
import { CommonModule } from '@angular/common';

declare global {
  interface Window {
    receiveData: (data: any) => void;
  }
}

@Component({
  selector: 'app-win-chart',
  standalone: true,
  imports: [ChartsModule, CommonModule],
  templateUrl: './win-chart.component.html',
  styleUrls: ['./win-chart.component.css']
})
export class WinChartComponent {
  public winFormsData: any = null;
  public typeChart: SeriesType = "pie";
  
  constructor() {
    window.receiveData = (data: any) => {
      this.winFormsData = data;  
      localStorage.setItem('winFormsData', JSON.stringify(data)); 
    }; 
  }
  
  ngOnInit() {
    const savedData = localStorage.getItem('winFormsData');
    if (savedData) {
      this.winFormsData = JSON.parse(savedData);
    }
  }

  public label(args: LegendLabelsContentArgs): string {
    return `${args.dataItem.name}`;
  } 

  // Function to dispatch the custom event
  sendEvent() {

 
  };

  onSeriesClick(event: SeriesClickEvent): void {
    const category = event.category;
    const value = event.value;
    
    console.log('Category:', category);
    console.log('Value:', value); 

    const message = JSON.stringify({ category, value });

    // Create a new custom event
    const eventClick = new CustomEvent('MyClick', {
      detail: { message: message }, // Pass any necessary data
    });  

    window.dispatchEvent(eventClick);    
 
  }

}
 