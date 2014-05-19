export class PageCode {
  on: (name: string, callback: (data?: Object) => void, context?: any) => void;
  off: (name: string, callback: (data?: Object) => void, context?: any) => void;
  once: (name: string, callback: (data?: Object) => void, context?: any) => void;
  trigger: (eventName: string, data?: Object) => void;
}

export class ControlBase {
  app: Application;
  el: Element;

  defineProperty: (propertyName: string, initialValue?: any) => void;

  on: (name: string, callback: (data?: Object) => void, context?: any) => void;
  off: (name: string, callback: (data?: Object) => void, context?: any) => void;
  once: (name: string, callback: (data?: Object) => void, context?: any) => void;
  trigger: (eventName: string, data?: Object) => void;
}

