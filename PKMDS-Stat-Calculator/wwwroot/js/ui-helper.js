function changeTheme(isDark) {
    if (isDark)
        document.body.classList.add('dark-theme');
    else
        document.body.classList.remove('dark-theme');
};

function addToLocalStorage(key, value) {
    localStorage[key] = value;
};

function readFromLocalStorage(key, valueIfMissing) {
    return localStorage[key] ?? valueIfMissing;
};
