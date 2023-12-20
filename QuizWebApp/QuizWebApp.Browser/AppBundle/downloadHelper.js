// Convert a base64 string to a Uint8Array. This is needed to create a blob object from the base64 string.
// The code comes from: https://developer.mozilla.org/fr/docs/Web/API/WindowBase64/D%C3%A9coder_encoder_en_base64
export function b64ToUint6(nChr) {
    return nChr > 64 && nChr < 91 ? nChr - 65 : nChr > 96 && nChr < 123 ? nChr - 71 : nChr > 47 && nChr < 58 ? nChr + 4 : nChr === 43 ? 62 : nChr === 47 ? 63 : 0;
}
export function base64DecToArr(sBase64, nBlocksSize) {
    var
        sB64Enc = sBase64.replace(/[^A-Za-z0-9\+\/]/g, ""),
    nInLen = sB64Enc.length,
        nOutLen = nBlocksSize ? Math.ceil((nInLen * 3 + 1 >> 2) / nBlocksSize) * nBlocksSize : nInLen * 3 + 1 >> 2,
        taBytes = new Uint8Array(nOutLen);

    for (var nMod3, nMod4, nUint24 = 0, nOutIdx = 0, nInIdx = 0; nInIdx < nInLen; nInIdx++) {
        nMod4 = nInIdx & 3;
        nUint24 |= b64ToUint6(sB64Enc.charCodeAt(nInIdx)) << 18 - 6 * nMod4;
        if (nMod4 === 3 || nInLen - nInIdx === 1) {
            for (nMod3 = 0; nMod3 < 3 && nOutIdx < nOutLen; nMod3++, nOutIdx++) {
                taBytes[nOutIdx] = nUint24 >>> (16 >>> nMod3 & 24) & 255;
            }
            nUint24 = 0;
        }
    }
    return taBytes;
}
export function downloadFile(filename, contentType, content) {
    try {
        // Blazor marshall byte[] to a base64 string, so we first need to convert the string (content) to a Uint8Array to create the File
        //const data = base64DecToArr(content);
        // Create the URL
        const file = new File([content], filename, { type: contentType });
        if (navigator.msSaveBlob) {
            navigator.msSaveBlob(file, filenameStr);
        }
        else {
            const exportUrl = URL.createObjectURL(file);
            // Create the <a> element and click on it
            const a = document.createElement("a");
            document.body.appendChild(a); // Needed for Firefox
            a.href = exportUrl;
            a.download = filename;
            a.target = "_self";
            a.click();
            // We don't need to keep the url, let's release the memory
            URL.revokeObjectURL(exportUrl);
            document.body.removeChild(a);
        }
    }
    catch (error) {
        return { Succeeded: false, ErrorName: error.name, ErrorMessage: error.message }
    }
    return { Succeeded: true, ErrorName: null, ErrorMessage: null }
}
export function downloadFileByte(filename, contentType, content) {
    try {
        // Blazor marshall byte[] to a base64 string, so we first need to convert the string (content) to a Uint8Array to create the File
        const data = base64DecToArr(content);
        // Create the URL
        const file = new File([data], filename, { type: contentType });
        if (navigator.msSaveBlob) {
            navigator.msSaveBlob(file, filenameStr);
        }
        else {
            const exportUrl = URL.createObjectURL(file);
            // Create the <a> element and click on it
            const a = document.createElement("a");
            document.body.appendChild(a); // Needed for Firefox
            a.href = exportUrl;
            a.download = filename;
            a.target = "_self";
            a.click();
            // We don't need to keep the url, let's release the memory
            URL.revokeObjectURL(exportUrl);
            document.body.removeChild(a);
        }
    }
    catch (error) {
        return { Succeeded: false, ErrorName: error.name, ErrorMessage: error.message }
    }
    return { Succeeded: true, ErrorName: null, ErrorMessage: null }
}
export function downloadFileFast(filename, contentType, content) {
    try {
        // Convert the parameters to actual JS types
        const filenameStr = BINDING.conv_string(filename);
        const contentTypeStr = BINDING.conv_string(contentType);
        const contentArray = Blazor.platform.toUint8Array(content);
        // Create the URL
        const file = new File([contentArray], filenameStr, { type: contentTypeStr });
        if (navigator.msSaveBlob) {
            navigator.msSaveBlob(file, filenameStr);
        }
        else {
            const exportUrl = URL.createObjectURL(file);
            // Create the <a> element and click on it
            const a = document.createElement('a'); // Needed for Firefox
            document.body.appendChild(a);
            a.href = exportUrl;
            a.download = nameStr;
            a.target = '_self';
            a.click();
            // We don't need to keep the url, let's release the memory
            URL.revokeObjectURL(exportUrl);
            document.body.removeChild(a);
        }
    }
    catch (error) {
        return { Succeeded: false, ErrorName: error.name, ErrorMessage: error.message }
    }
    return { Succeeded: true, ErrorName: null, ErrorMessage: null }
}