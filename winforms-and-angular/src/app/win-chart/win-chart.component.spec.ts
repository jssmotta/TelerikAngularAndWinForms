import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WinChartComponent } from './win-chart.component';

describe('WinChartComponent', () => {
  let component: WinChartComponent;
  let fixture: ComponentFixture<WinChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WinChartComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WinChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
