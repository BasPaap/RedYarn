import { Component } from "@angular/core";
import { FormGroup } from "@angular/forms";

@Component({
  template: ''
})
export class DialogComponent {
  private toggleFormControlsEnabled() {
    for (let key in this.formGroup.controls) {
      if (this.formGroup.controls[key].disabled) {
        this.formGroup.controls[key].enable();
      }
      else {
        this.formGroup.controls[key].disable();
      }
    }
  }
  
  private _isSubmitting: boolean = false;
  protected get isSubmitting(): boolean {
    return this._isSubmitting;
  }

  public formGroup: FormGroup = new FormGroup({});

  protected toggleSubmitting() {
    this._isSubmitting = !this._isSubmitting;
    this.toggleFormControlsEnabled();
  }

  constructor() {    
  }
}
