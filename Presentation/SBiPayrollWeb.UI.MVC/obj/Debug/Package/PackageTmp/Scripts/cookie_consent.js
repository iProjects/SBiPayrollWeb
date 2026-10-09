
///Reusable Cookie & Persistence Manager (cookie-manager.js)
//This module uses ES6 async/await and Promises to handle writing and reading consent records across localStorage, IndexedDB, and standard browser cookies without third-party dependencies:
var CookieConsent = (function (window, $) {
    "use strict";

    var STORAGE_KEY = "app_cookie_consent_v1";
    var DB_NAME = "AppStorageDB";
    var DB_VERSION = 1;
    var STORE_NAME = "user_preferences";

    // --- 1. INDEXEDDB HELPER WRAPPER ---
    function openDB() {
        return new Promise(function (resolve, reject) {
            if (!("indexedDB" in window)) {
                reject("IndexedDB not supported");
                return;
            }

            var request = window.indexedDB.open(DB_NAME, DB_VERSION);

            request.onupgradeneeded = function (event) {
                var db = event.target.result;
                if (!db.objectStoreNames.contains(STORE_NAME)) {
                    db.createObjectStore(STORE_NAME, { keyPath: "id" });
                }
            };

            request.onsuccess = function (event) {
                resolve(event.target.result);
            };

            request.onerror = function (event) {
                reject("IndexedDB error: " + event.target.error);
            };
        });
    }

    function saveToIndexedDB(consentData) {
        return openDB().then(function (db) {
            return new Promise(function (resolve, reject) {
                var tx = db.transaction(STORE_NAME, "readwrite");
                var store = tx.objectStore(STORE_NAME);

                var record = {
                    id: STORAGE_KEY,
                    data: consentData,
                    timestamp: new Date().toISOString()
                };

                var request = store.put(record);

                request.onsuccess = function () {
                    resolve(true);
                };

                request.onerror = function (event) {
                    reject("Failed to store in IndexedDB: " + event.target.error);
                };
            });
        }).catch(function (err) {
            console.warn(err);
        });
    }

    function readFromIndexedDB() {
        return openDB().then(function (db) {
            return new Promise(function (resolve, reject) {
                var tx = db.transaction(STORE_NAME, "readonly");
                var store = tx.objectStore(STORE_NAME);
                var request = store.get(STORAGE_KEY);

                request.onsuccess = function (event) {
                    if (request.result) {
                        resolve(request.result.data);
                    } else {
                        resolve(null);
                    }
                };

                request.onerror = function () {
                    resolve(null);
                };
            });
        }).catch(function () {
            return null;
        });
    }

    // --- 2. LOCAL STORAGE HELPER ---
    function saveToLocalStorage(consentData) {
        try {
            window.localStorage.setItem(STORAGE_KEY, JSON.stringify(consentData));
        } catch (e) {
            console.warn("LocalStorage unavailable: " + e);
        }
    }

    function readFromLocalStorage() {
        try {
            var item = window.localStorage.getItem(STORAGE_KEY);
            return item ? JSON.parse(item) : null;
        } catch (e) {
            return null;
        }
    }

    // --- 3. PUBLIC COOKIE CONSENT MODULE METHODS ---
    return {
        init: function () {
            var self = this;

            // Check if consent preferences exist in LocalStorage or IndexedDB
            self.loadConsent().then(function (consent) {
                if (!consent) {
                    // Show consent banner if no saved preferences exist
                    $("#cookieConsentBanner").removeClass("displaynone");
                } else {
                    // Apply user's existing settings
                    self.applyConsent(consent);
                }
            });

            // Event Listeners
            $("#btnAcceptAll").on("click", function () {
                var consent = { essential: true, analytics: true, marketing: true };
                self.saveConsent(consent);
            });

            $("#btnRejectAll").on("click", function () {
                var consent = { essential: true, analytics: false, marketing: false };
                self.saveConsent(consent);
            });

            $("#btnSaveCustom").on("click", function () {
                var consent = {
                    essential: true,
                    analytics: $("#chkAnalytics").is(":checked"),
                    marketing: $("#chkMarketing").is(":checked")
                };
                self.saveConsent(consent);
            });
        },

        saveConsent: function (consentData) {
            var payload = {
                preferences: consentData,
                consentedAt: new Date().toISOString()
            };

            // 1. Persist to LocalStorage
            saveToLocalStorage(payload);

            // 2. Persist to IndexedDB
            saveToIndexedDB(payload);

            // Hide Banner
            $("#cookieConsentBanner").addClass("displaynone");

            // Apply selected tracking/services
            this.applyConsent(payload);

            if (typeof AppUI !== "undefined" && typeof AppUI.showToast === "function") {
                AppUI.showToast("Privacy preferences saved.", "success");
            }
        },

        loadConsent: function () {
            // First check LocalStorage (faster)
            var localData = readFromLocalStorage();
            if (localData) {
                return Promise.resolve(localData);
            }

            // Fallback to IndexedDB if LocalStorage was cleared or unavailable
            return readFromIndexedDB();
        },

        applyConsent: function (consentRecord) {
            var prefs = consentRecord.preferences || {};

            if (prefs.analytics) {
                // Initialize/enable Analytics scripts (e.g., Google Analytics)
                console.log("Analytics enabled.");
            }

            if (prefs.marketing) {
                // Initialize/enable Marketing pixels (e.g., Meta Pixel)
                console.log("Marketing enabled.");
            }
        }
    };
})(window, jQuery);

// Initialize on page load
$(document).ready(function () {
    CookieConsent.init();
});




(function () {
    if (!localStorage.getItem('cookieconsent')) {
        document.body.innerHTML += '\
		<div class="cookieconsent" style="position:fixed;padding:20px;left:0;bottom:0;background-color:#000;color:#FFF;text-align:center;width:100%;z-index:99999;">\
			This site uses cookies. By continuing to use this website, you agree to their use. \
			<a href="#" style="background-color:#fff;color:#000;padding:2px">I Understand</a>\
		</div>\
		';
        document.querySelector('.cookieconsent a').onclick = function (e) {
            e.preventDefault();
            document.querySelector('.cookieconsent').style.display = 'none';
            localStorage.setItem('cookieconsent', true);
        };
    }
})();