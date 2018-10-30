import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ENTER, SEMICOLON } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material';

@Component({
  selector: 'app-chips-input',
  templateUrl: './chips-input.component.html',
  styleUrls: ['./chips-input.component.scss']
})
export class ChipsInputComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  @Input() public label: string;
  @Input() public firstHint: string;
  @Input() public secondHint: string;

  @Input() values: string[] = [];
  @Output() valuesChange = new EventEmitter<string[]>();
  
  readonly separatorKeyCodes: number[] = [ENTER, SEMICOLON];
  removable = true;

  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if ((value || '').trim()) {
      this.values.push(value.trim());
    }

    // Reset the input value
    if (input) {
      input.value = '';
    }

    this.valuesChange.emit(this.values);
  }

  remove(value: string): void {
    const index = this.values.indexOf(value);

    if (index >= 0) {
      this.values.splice(index, 1);

      this.valuesChange.emit(this.values);
    }
  }

}
