import { ENTER, SEMICOLON } from '@angular/cdk/keycodes';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatChipInputEvent } from '@angular/material';
import { Guid } from 'src/Guid';

export interface ChipValue {
  id: string;
  name: string;
}

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

  @Input() public values: ChipValue[] = [];
  @Output() public valuesChange = new EventEmitter<ChipValue[]>();
  
  public readonly separatorKeyCodes: number[] = [ENTER, SEMICOLON];
  public removable = true;

  public add(event: MatChipInputEvent): void {
    const input = event.input;
    const name = event.value;

    if ((name || '').trim()) {

      let value = {
        id: Guid.empty,
        name: name.trim()
      };

      this.values.push(value);
    }

    // Reset the input value
    if (input) {
      input.value = '';
    }

    this.valuesChange.emit(this.values);
  }

  public remove(value: ChipValue): void {
    const index = this.values.indexOf(value);

    if (index >= 0) {
      this.values.splice(index, 1);

      this.valuesChange.emit(this.values);
    }
  }

}
