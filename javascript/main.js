function showConfirmation(sender, args) {
    document.getElementById('UploadErrorLbl').innerHTML = 'upload complete.' + "<br />Uploaded File Name: " + args.get_fileName();
}

function UploadError(sender, args) {
    alert(args.get_errorMessage());
}