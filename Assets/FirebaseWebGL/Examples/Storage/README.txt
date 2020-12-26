For Firebase Storage to work properly on the web, you need to set up cors for your bucket.
You can look more into it here: https://firebase.google.com/docs/storage/web/download-files#cors_configuration
Or just open a terminal in this folder and run this command gsutil cors set cors.json gs://<your-cloud-storage-bucket> for a quick setup.
