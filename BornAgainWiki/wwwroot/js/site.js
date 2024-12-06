// Check if the dark-mode cookie is set
let darkModeCookie = getCookie('dark-mode');

if (!darkModeCookie) {
    // No cookie set, use system preference
    const prefersDarkMode = window.matchMedia('(prefers-color-scheme: dark)').matches;

    // Set the dark-mode cookie based on system preference
    darkModeCookie = prefersDarkMode ? 'dark-mode' : 'light-mode';
    setCookie('dark-mode', darkModeCookie);
}

// Apply the theme based on the cookie value
document.documentElement.setAttribute('data-bs-theme', darkModeCookie === 'dark-mode' ? "dark" : "light");

// Optional: Listen for changes in system preference and update the cookie
window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', (event) => {
    const newPreference = event.matches ? 'dark-mode' : 'light-mode';
    setCookie('dark-mode', newPreference, 365);
    document.documentElement.setAttribute('data-bs-theme', event.matches ? "dark" : "light");
});

document.getElementById("searchInput").addEventListener("input", function () {
    let query = this.value.trim();
    let resultsDiv = document.getElementById("searchResults");

    if (query.length > 2) {
        fetch(`/search/results?s=${encodeURIComponent(query)}`)
            .then(response => response.json())
            .then(data => {
                resultsDiv.innerHTML = ""; // Clear previous results
                if (data.length > 0) {
                    data.forEach(item => {
                        let div = document.createElement("div");
                        div.classList.add('dropdown-item');
                        div.innerHTML = `
                            <div class="row align-items-center">
                                <div class="col-auto">
                                    <img class="sprite" src='${item.image}?s=s'>
                                </div>
                                <div class="col">
                                    ${highlightMatches(item.title, query)}
                                </div>
                            </div>
                        `;

                        div.onclick = () => {
                            window.location.href = item.pageKey;
                        };
                        resultsDiv.appendChild(div);
                    });
                    resultsDiv.style.display = "block";
                } else {
                    resultsDiv.style.display = "none";
                }
            })
            .catch(error => console.error("Error fetching search results:", error));
    } else {
        resultsDiv.style.display = "none";
    }
});

// Function to highlight matches in a string
function highlightMatches(text, query) {
    if (!query) return text;
    const regex = new RegExp(`(${query})`, 'gi'); // Match query case-insensitively
    return text.replace(regex, '<strong>$1</strong>'); // Wrap matches in <strong> tags
}

// Hide dropdown when search input loses focus
document.getElementById("searchInput").addEventListener("blur", function () {
    setTimeout(() => {
        document.getElementById("searchResults").style.display = "none";
    }, 250); // Delay to allow click event to register
});

// Show dropdown when search input gains focus, if results are available
document.getElementById("searchInput").addEventListener("focus", function () {
    let resultsDiv = document.getElementById("searchResults");
    if (resultsDiv.innerHTML.trim() !== "") {
        resultsDiv.style.display = "block";
    }
});

document.getElementById("searchForm").addEventListener("submit", function (event) {
    const searchInput = document.getElementById("searchInput").value.trim();
    if (searchInput.length > 0) {
        // Append the search string as a query parameter with name 's'
        this.action = `/search?s=${encodeURIComponent(searchInput)}`;
    } else {
        event.preventDefault(); // Prevent submission if the search string is empty
    }
});