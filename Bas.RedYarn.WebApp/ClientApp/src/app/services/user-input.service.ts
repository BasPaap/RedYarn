import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

export interface MouseState {
  isButtonDown: boolean,
  x: number,
  y: number
}

@Injectable({
  providedIn: 'root'
})
export class UserInputService {

  private mouseState: MouseState = {
    isButtonDown: false,
    x: 0,
    y: 0
  };

  private mouseStateSubject: Subject<MouseState> = new Subject<MouseState>();

  public get mouseStateStream(): Observable<MouseState> {
    return this.mouseStateSubject.asObservable();
  }

  constructor() { }

  public onMouseUp() {
    this.mouseState.isButtonDown = false;
    this.mouseStateSubject.next(this.mouseState);
  }

  public onMouseDown() {
    this.mouseState.isButtonDown = true;
    this.mouseStateSubject.next(this.mouseState);
  }

  public onMouseMove(x: number, y: number, buttons: number) {
    this.mouseState.x = x;
    this.mouseState.y = y;
    this.mouseState.isButtonDown = buttons == 1;
    this.mouseStateSubject.next(this.mouseState);
  }
}
