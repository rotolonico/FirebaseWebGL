const functions = require('firebase-functions');

const cors = require('cors')({origin: true});

exports.helloWorld = functions.https.onRequest((request, response) => {
  cors(request, response, () => {});
  response.send("Hello from Firebase!");
});

exports.reverseMessage = functions.https.onRequest((request, response) => {
  var message = request.query.message;
  cors(request, response, () => {});
  if (message === null) response.send ("Message parameter is null!");
  response.send(message.split("").reverse().join(""));
});

exports.sum = functions.https.onRequest((request, response) => {
  var a = parseInt(request.query.a);
  var b = parseInt(request.query.b)
  cors(request, response, () => {});
  if (a === null || b === null) response.send("A or b parameters are null!");
  var sum = a + b;
  response.send("\"" + sum + "\"");
});
