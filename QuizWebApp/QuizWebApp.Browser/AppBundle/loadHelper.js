export async function loadFile() {
    const [fileHandle] = await window.showOpenFilePicker()

    const file = await fileHandle.getFile()
    const fileContent = await file.text()

    window.exports.QuizWebApp.LoadHelper.PushJson(fileContent);
}