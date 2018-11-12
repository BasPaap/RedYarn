import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

export interface MouseState {
  isButtonDown: boolean,
  xCoordinate: number,
  yCoordinate: number
}

@Injectable({
  providedIn: 'root'
})
export class UserInputService {

  private mouseState: MouseState = {
    isButtonDown: false,
    xCoordinate: 0,
    yCoordinate: 0
  };

  private mouseStateSubject: Subject<MouseState>;

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

  public onMouseMove(x: number, y: number) {
    this.mouseState.xCoordinate = x;
    this.mouseState.yCoordinate = y;
    this.mouseStateSubject.next(this.mouseState);
  }
}
