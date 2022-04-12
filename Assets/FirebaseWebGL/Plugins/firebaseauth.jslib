mergeInto(LibraryManager.library, {

    SignInAnonymously: function (objectName, id, callback, fallback) {
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {
            firebase.auth().signInAnonymously().then(function (result) {
                unityInstance.Module.SendMessage(parsedObjectName, parsedCallback, JSON.stringify({id: id, result: "Success: signed up for " + result}));
            }).catch(function (error) {
                var errorStringfy = JSON.stringify(error, Object.getOwnPropertyNames(error))
                unityInstance.Module.SendMessage(parsedObjectName, parsedFallback, JSON.stringify({ id: id, result: JSON.parse(errorStringfy) }));
            });

        } catch (error) {
            var errorStringfy = JSON.stringify(error, Object.getOwnPropertyNames(error))
            unityInstance.Module.SendMessage(parsedObjectName, parsedFallback, JSON.stringify({ id: id, result: JSON.parse(errorStringfy) }));
        }
    },
    
    CreateUserWithEmailAndPassword: function (email, password, objectName, id, callback, fallback) {
        var parsedEmail = UTF8ToString(email);
        var parsedPassword = UTF8ToString(password);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.auth().createUserWithEmailAndPassword(parsedEmail, parsedPassword).then(function (unused) {

                unityInstance.Module.SendMessage(parsedObjectName, parsedCallback, JSON.stringify({id: id, result: "Success: signed up for " + parsedEmail}));
            }).catch(function (error) {

                var errorStringfy = JSON.stringify(error, Object.getOwnPropertyNames(error))
                unityInstance.Module.SendMessage(parsedObjectName, parsedFallback, JSON.stringify({ id: id, result: JSON.parse(errorStringfy) }));
            });

        } catch (error) {
            var errorStringfy = JSON.stringify(error, Object.getOwnPropertyNames(error))
            unityInstance.Module.SendMessage(parsedObjectName, parsedFallback, JSON.stringify({ id: id, result: JSON.parse(errorStringfy) }));
        }
    },

    SignInWithEmailAndPassword: function (email, password, objectName, id, callback, fallback) {
        var parsedEmail = UTF8ToString(email);
        var parsedPassword = UTF8ToString(password);
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {

            firebase.auth().signInWithEmailAndPassword(parsedEmail, parsedPassword).then(function (unused) {
                unityInstance.Module.SendMessage(parsedObjectName, parsedCallback, JSON.stringify({id: id, result: "Success: signed in for " + parsedEmail}));
            }).catch(function (error) {

                var errorStringfy = JSON.stringify(error, Object.getOwnPropertyNames(error))
                unityInstance.Module.SendMessage(parsedObjectName, parsedFallback, JSON.stringify({ id: id, result: JSON.parse(errorStringfy) }));
            });

        } catch (error) {

            var errorStringfy = JSON.stringify(error, Object.getOwnPropertyNames(error))
            unityInstance.Module.SendMessage(parsedObjectName, parsedFallback, JSON.stringify({ id: id, result: JSON.parse(errorStringfy) }));
        }
    },

    SignInWithGoogle: function (objectName, id, callback, fallback) {
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {
            var provider = new firebase.auth.GoogleAuthProvider();
            firebase.auth().signInWithRedirect(provider).then(function (unused) {
                unityInstance.Module.SendMessage(parsedObjectName, parsedCallback, JSON.stringify({id: id, result: "Success: signed in with Google!"}));
            }).catch(function (error) {

                var errorStringfy = JSON.stringify(error, Object.getOwnPropertyNames(error))
                unityInstance.Module.SendMessage(parsedObjectName, parsedFallback, JSON.stringify({ id: id, result: JSON.parse(errorStringfy) }));
            });

        } catch (error) {

            var errorStringfy = JSON.stringify(error, Object.getOwnPropertyNames(error))
            unityInstance.Module.SendMessage(parsedObjectName, parsedFallback, JSON.stringify({ id: id, result: JSON.parse(errorStringfy) }));
        }
    },

    SignInWithFacebook: function (objectName, id, callback, fallback) {
        var parsedObjectName = UTF8ToString(objectName);
        var parsedCallback = UTF8ToString(callback);
        var parsedFallback = UTF8ToString(fallback);

        try {
            var provider = new firebase.auth.FacebookAuthProvider();
            firebase.auth().signInWithRedirect(provider).then(function (unused) {
                unityInstance.Module.SendMessage(parsedObjectName, parsedCallback, JSON.stringify({id: id, result: "Success: signed in with Facebook!"}));
            }).catch(function (error) {

                var errorStringfy = JSON.stringify(error, Object.getOwnPropertyNames(error))
                unityInstance.Module.SendMessage(parsedObjectName, parsedFallback, JSON.stringify({ id: id, result: JSON.parse(errorStringfy) }));
            });

        } catch (error) {

            var errorStringfy = JSON.stringify(error, Object.getOwnPropertyNames(error))
            unityInstance.Module.SendMessage(parsedObjectName, parsedFallback, JSON.stringify({ id: id, result: JSON.parse(errorStringfy) }));
        }
    },

    OnAuthStateChanged: function (objectName, id, onUserSignedIn, onUserSignedOut) {
        var parsedObjectName = UTF8ToString(objectName);
        var parsedOnUserSignedIn = UTF8ToString(onUserSignedIn);
        var parsedOnUserSignedOut = UTF8ToString(onUserSignedOut);

        firebase.auth().onAuthStateChanged(function(user) {
            if (user) {
                unityInstance.Module.SendMessage(parsedObjectName, parsedOnUserSignedIn, JSON.stringify({id: id, result: user}));
            } else {
                unityInstance.Module.SendMessage(parsedObjectName, parsedOnUserSignedOut, JSON.stringify({id: id, result: "User signed out"}));
            }
        });

    }
});
