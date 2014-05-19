interface SitecoreSpeak {
  component(deps: Array<string>, componentType: new () => any, componentName?: string): void;
  component(componentType: new () => any, componentName?: string): void;

  module(name: string, moduleDefinition: any): any;

  pageCode(deps: Array<string>, pageCode: any): void;
  pageCode(pageCode: any): void;
  
  plugin(deps: Array<string>, pageCode: any): void;
  plugin(pageCode: any): void;

  propertyType(propertyType: PropertyTypeDefinition)

  app: Application;
  applications: Array<Application>;
  applyPlugins(obj);
  async: any;
  exposeComponent(comp, app);
  extend(obj: Object);
  init(callback);
  isDebug(): boolean;
  listenTo(obj, name, callback);
  listenToOnce(obj, name, callback);
  loaded: any;
  off(name: string, callback: (data?: Object) => void, context?: any);
  on(name: string, callback: (data?: Object, args?: Object) => void, context?: any);
  once(name: string, callback: (data?: Object) => void, context?: any);
  ready(callback);
  stopListening(obj, name, callback): void;
  template: any;
  tmpl: any;
  trigger(eventName: string, data?: Object);
  uniqueId(prefix: string);
  utils: any;

  Events: Events;
}

interface Application {
  children: Array<Application>;
  components: Array<Component>;
  depth: number;
  el: Element;
  findApplication(appName: string): Application;
  findComponent(componentName: string): Component;
  key: string;
  listenTo: any;
  listenToOnce: any;
  off(name: string, callback: (data?: Object) => void, context?: any);
  on(name: string, callback: (data?: Object, args?: Object) => void, context?: any);
  once(name: string, callback: (data?: Object) => void, context?: any);
  pageCode: any;
  parent: Application;
  stopListening(obj, name, callback): void;
  trigger(eventName: string, data?: Object);
  closeDialog(returnValue: any): void;
  remove(el: string): Application;
  replace(config: any, callback): void;
  append(config: any, callback): void;
  prepend(config: any, callback): void;
  insertRendering(itemId: string, options:any, callback): void;
  insertMarkups(html: string, name: string, options:any, callback): void;
  inject(config: any, callback): void;
}

interface Component {
  app: Application;
  children: Array<Component>;
  depth: number;
  el: Element;
  hasTemplate: boolean;
  initialize(initial: ComponentOptions, app: Application, el: Element, sitecore: SitecoreSpeak): void;
  initialized(initial: ComponentOptions, app: Application, el: Element, sitecore: SitecoreSpeak): void;
  id: string;
  key: string;                                                                                  
  listenTo(obj, name, callback);
  listenToOnce(obj, name, callback);
  name: string;
  off(name: string, callback: (data?: Object) => void, context?: any);
  on(name: string, callback: (data?: Object, args?: Object) => void, context?: any);
  once(name: string, callback: (data?: Object) => void, context?: any);
  parent: Component;
  placeholder: any;
  presenter: string;
  presenterScript: string;
  properties: any;
  render(): void;
  serialize(): void;
  script: string;
  template: any;
  trigger(eventName: string, data?: Object);
  type: string;
}

interface ComponentOptions {
  presenter: string;
  depth: number;
  el: Element;
  hasTemplate: boolean;
  id: string;
  key: string;
  name: string;
  parent: Element;
  script: string;
  template: any;
}

interface PropertyTypeDefinition {
  name: string;
  get(propertyName: string): any;
  set?: (newValue: any) => void;
  isNew?: (newValue: any) => boolean;
}

interface Events {
  handleEvent(eventName: string, sender: any);
}

declare var Sitecore: SitecoreSpeak;
