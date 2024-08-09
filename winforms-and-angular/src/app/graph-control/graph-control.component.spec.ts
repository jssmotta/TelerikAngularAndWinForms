import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphControlComponent } from './graph-control.component';

describe('GraphControlComponent', () => {
  let component: GraphControlComponent;
  let fixture: ComponentFixture<GraphControlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GraphControlComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GraphControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
