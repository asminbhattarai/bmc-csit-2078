// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Local Storage
function setLocalStorage() {
    localStorage.setItem('userTheme', 'dark');
    localStorage.setItem('fontSize', '16');
    updateUI();
}

function getLocalStorage() {
    const theme = localStorage.getItem('userTheme') || 'light';
    const fontSize = localStorage.getItem('fontSize') || '14';
    return { theme, fontSize };
}

// Session Storage
function setSessionStorage() {
    sessionStorage.setItem('userLanguage', 'es');
    updateUI();
}

function getSessionStorage() {
    return sessionStorage.getItem('userLanguage') || 'en';
}

function updateUI() {
    const { theme, fontSize } = getLocalStorage();
    const language = getSessionStorage();
    
    document.getElementById('clientState').innerHTML = `
        <p>Theme (LocalStorage): ${theme}</p>
        <p>Font Size (LocalStorage): ${fontSize}px</p>
        <p>Language (SessionStorage): ${language}</p>
    `;
}
