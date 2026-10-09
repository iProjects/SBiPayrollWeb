$(document).ready(function () {
    $("#progress").hide();
    $.ajaxSetup({ cache: false });

    $("#toggle-btn").on("click", function (e) {
        e.preventDefault(); // Prevents page reload or unintended submit

        var $input = $("#password-field");
        var isPassword = $input.prop("type") === "password";

        $input.prop("type", isPassword ? "text" : "password");
    });

    // Event delegation ensures click binding works properly
    $(document).on("click", ".js-password-toggle", function (e) {
        e.preventDefault(); // Prevents form submission

        var $input = $(this).siblings(".js-password-input");

        var isPassword = $input.prop("type") === "password";

        $input.prop("type", isPassword ? "text" : "password");

        // Swap SVG Icon
        if (isPassword) {
            $(this).html('<svg width="20" height="20" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858-5.908a8.962 8.962 0 012.122-.163c4.478 0 8.268 2.943 9.542 7a10.025 10.025 0 01-4.132 5.411m-1.38 1.38c-.372.234-.761.442-1.162.622M15 12a3 3 0 11-6 0 3 3 0 016 0z"/><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 3l18 18"/></svg>');
        } else {
            $(this).html('<svg width="20" height="20" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"/><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"/></svg>');
        }
    });

    // Form Submit Handling
    $("#btnSubmitLoginForm").on("click", function (e) {
        e.preventDefault();
        var $form = $("#login-form");

        if ($form.valid()) {
            $("#progress").removeClass('displaynone').addClass('displayblock').show();
            $form.submit();
        }
    });





    document.addEventListener('DOMContentLoaded', function () {
        var googleBtn = document.getElementById('btn-google-login');
        var googleBtnText = document.getElementById('google-btn-text');

        // Replace with your actual Client ID from Google Cloud Console
        var GOOGLE_CLIENT_ID = 'YOUR_GOOGLE_CLIENT_ID.apps.googleusercontent.com';
        var isSdkLoading = false;

        if (googleBtn) {
            googleBtn.addEventListener('click', function () {
                // 1. If SDK is already loaded and initialized, trigger auth directly
                if (window.google && window.google.accounts && window.google.accounts.id) {
                    triggerGoogleAuth();
                    return;
                }

                if (isSdkLoading) return;
                isSdkLoading = true;

                // UI feedback
                googleBtn.disabled = true;
                if (googleBtnText) googleBtnText.innerText = 'Connecting...';

                // 2. Load Google Identity Services library safely
                loadGoogleScript(function (err) {
                    isSdkLoading = false;
                    googleBtn.disabled = false;
                    if (googleBtnText) googleBtnText.innerText = 'Sign in with Google';

                    if (err) {
                        console.error('Failed to load Google SDK:', err);
                        alert('Unable to connect to Google. Please check your internet connection.');
                        return;
                    }

                    // Initialize Google Identity Services
                    try {
                        window.google.accounts.id.initialize({
                            client_id: GOOGLE_CLIENT_ID,
                            callback: handleGoogleCredentialResponse,
                            auto_select: false
                        });

                        triggerGoogleAuth();
                    } catch (error) {
                        console.error('Google Auth Initialization Error:', error);
                    }
                });
            });
        }

        function loadGoogleScript(callback) {
            if (document.getElementById('google-gsi-script')) {
                callback(null);
                return;
            }

            var script = document.createElement('script');
            script.id = 'google-gsi-script';
            script.src = 'https://accounts.google.com/gsi/client';
            script.async = true;
            script.defer = true;

            script.onload = function () {
                callback(null);
            };
            script.onerror = function (err) {
                callback(err);
            };

            document.head.appendChild(script);
        }

        function triggerGoogleAuth() {
            if (window.google && window.google.accounts && window.google.accounts.id) {
                // Prompt the Google One Tap / Sign-In dialog
                window.google.accounts.id.prompt(function (notification) {
                    if (notification.isUncanceled() === false || notification.isNotDisplayed()) {
                        // Fallback to explicit popup if One Tap is dismissed or blocked
                        var client = window.google.accounts.oauth2.initTokenClient({
                            client_id: GOOGLE_CLIENT_ID,
                            scope: 'email profile openid',
                            callback: function (response) {
                                if (response.access_token) {
                                    submitToken(response.access_token);
                                }
                            }
                        });
                        client.requestAccessToken();
                    }
                });
            }
        }

        function handleGoogleCredentialResponse(response) {
            if (response && response.credential) {
                submitToken(response.credential);
            }
        }

        function submitToken(token) {
            var tokenInput = document.getElementById('google_id_token');
            var googleForm = document.getElementById('google-login-form');

            if (tokenInput && googleForm) {
                tokenInput.value = token;
                googleForm.submit();
            }
        }
    });















});