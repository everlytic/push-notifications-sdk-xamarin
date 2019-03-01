## Testing SDK without Everlytic

Simple testing without needing to send messages through the product

#### `package.json`
```json
{
  "name": "pushtest",
  "version": "1.0.0",
  "description": "",
  "main": "index.js",
  "scripts": {
    "test": "echo \"Error: no test specified\" && exit 1"
  },
  "author": "",
  "license": "ISC",
  "dependencies": {
    "firebase-admin": "^6.5.1"
  }
}

```

#### `index.js`
```javascript
const admin = require('firebase-admin');
const sa = require('./auth.json'); // service account .json file

const tokens = [
    // insert device tokens from logcat
];

admin.initializeApp({
    credential: admin.credential.cert(sa)
});

tokens.forEach((token) => {
    const message = {
        "token": token,
        "android": {
            "priority" : "high",
        },
        "data": {
            "title": "This is a notification title",
            "body": "This is some body content",
            "message_id": "15",
        }
    };

    console.log("Sending to token: ", token);

    admin.messaging().send(message)
        .then(function (resp) {
            console.log(resp);
        })
        .catch(function (err) {
            console.error(err)
        });
});
```