mergeInto(LibraryManager.library, {

    GetJSON: function(path, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.database().ref(parsedPath).once('value').then(function(snapshot) {
                window.unityInstance.SendMessage(parsedObjectName, parsedCallback, JSON.stringify(snapshot.val()));
            });

        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    PostJSON: function(path, value, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedValue = UTF8ToString(value);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.database().ref(parsedPath).set(JSON.parse(parsedValue)).then(function(unused) {
                window.unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: " + parsedValue + " was posted to " + parsedPath);
            });

        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    PushJSON: function(path, value, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedValue = UTF8ToString(value);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.database().ref(parsedPath).push().set(JSON.parse(parsedValue)).then(function(unused) {
                window.unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: " + parsedValue + " was pushed to " + parsedPath);
            });

        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    UpdateJSON: function(path, value, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedValue = UTF8ToString(value);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.database().ref(parsedPath).update(JSON.parse(parsedValue)).then(function(unused) {
                window.unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: " + parsedValue + " was updated in " + parsedPath);
            });

        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    DeleteJSON: function(path, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.database().ref(parsedPath).remove().then(function(unused) {
                window.unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: " + parsedPath + " was deleted");
            });

        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    ListenForValueChanged: function(path, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.database().ref(parsedPath).on('value', function(snapshot) {
                window.unityInstance.SendMessage(parsedObjectName, parsedCallback, JSON.stringify(snapshot.val()));
            });

        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    StopListeningForValueChanged: function(path, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {
            firebase.database().ref(parsedPath).off('value');
            window.unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: listener removed");
        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    ListenForChildAdded: function(path, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.database().ref(parsedPath).on('child_added', function(snapshot) {
                window.unityInstance.SendMessage(parsedObjectName, parsedCallback, JSON.stringify(snapshot.val()));
            });

        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    StopListeningForChildAdded: function(path, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {
            firebase.database().ref(parsedPath).off('child_added');
            window.unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: listener removed");
        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    ListenForChildChanged: function(path, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.database().ref(parsedPath).on('child_changed', function(snapshot) {
                window.unityInstance.SendMessage(parsedObjectName, parsedCallback, JSON.stringify(snapshot.val()));
            });

        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    StopListeningForChildChanged: function(path, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {
            firebase.database().ref(parsedPath).off('child_changed');
            window.unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: listener removed");
        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    ListenForChildRemoved: function(path, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.database().ref(parsedPath).on('child_removed', function(snapshot) {
                window.unityInstance.SendMessage(parsedObjectName, parsedCallback, JSON.stringify(snapshot.val()));
            });

        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    StopListeningForChildRemoved: function(path, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {
            firebase.database().ref(parsedPath).off('child_removed');
            window.unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: listener removed");
        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    ModifyNumberWithTransaction: function(path, amount, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.database().ref(parsedPath).transaction(function(currentValue) {
                if (!isNaN(currentValue)) {
                    return currentValue + amount;
                } else {
                    return amount;
                }
            }).then(function(unused) {
                window.unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: transaction run in " + parsedPath);
            });

        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    ToggleBooleanWithTransaction: function(path, objectName, callback, fallback) {
        var parsedPath = UTF8ToString(path);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.database().ref(parsedPath).transaction(function(currentValue) {
                if (typeof currentValue === "boolean") {
                    return !currentValue;
                } else {
                    return true;
                }
            }).then(function(unused) {
                window.unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: transaction run in " + parsedPath);
            });

        } catch (error) {
            window.unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    }

});