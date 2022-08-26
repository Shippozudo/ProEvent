/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PanelistComponent } from './Panelist.component';

describe('PanelistComponent', () => {
  let component: PanelistComponent;
  let fixture: ComponentFixture<PanelistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PanelistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PanelistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
