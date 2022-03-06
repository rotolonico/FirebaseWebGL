mergeInto(LibraryManager.library, {
    SetUserProperties: function(properties) {
        var props = JSON.parse(Pointer_stringify(properties));
		
        firebase.analytics().setUserProperties(props);
    },
	
    LogEvent: function(eventName) {
        var event_name = Pointer_stringify(eventName);
		
        firebase.analytics().logEvent(event_name);
    },
	
    LogEventParameter: function(eventName, eventParameter) {
        var event_name = Pointer_stringify(eventName);
        var event_param = JSON.parse(Pointer_stringify(eventParameter));
		
        firebase.analytics().logEvent(event_name, event_param);
    }
});