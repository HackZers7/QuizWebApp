export async function loadFile() {
    const pickerOpts = {
        types: [
            {
                description: "Json",
                accept: {
                    "text/json": [".json"],
                },
            },
        ],
        excludeAcceptAllOption: true,
        multiple: false,
    };
    
    const [fileHandle] = await window.showOpenFilePicker(pickerOpts)

    const file = await fileHandle.getFile()
    const fileContent = await file.text()

    window.exports.QuizWebApp.LoadHelper.PushJson(fileContent);
}