
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
    $("#btnSubmitRegisterForm").on("click", function (e) {
        e.preventDefault();
        var $form = $("#register-form");

        if ($form.valid()) {
            $("#progress").removeClass('displaynone').addClass('displayblock').show();
            $form.submit();
        }
    });

    // Password Strength Evaluator Logic
    $("#Password").on("input focus", function () {
        var password = $(this).val();

        if (password.length === 0) {
            $("#strengthContainer").slideUp(200);
            return;
        }

        $("#strengthContainer").slideDown(200);

        var rules = {
            length: password.length >= 8,
            lower: /[a-z]/.test(password),
            upper: /[A-Z]/.test(password),
            number: /[0-9]/.test(password),
            // Fix: Explicitly test against allowed special characters instead of negating alphanumeric
            special: /[!@@#$%^&*(),.?":{}|<>\-_+=\[\]\\\/]/.test(password)
        };

        // Update Rule Indicators
        updateRule("#ruleLength", rules.length);
        updateRule("#ruleLower", rules.lower);
        updateRule("#ruleUpper", rules.upper);
        updateRule("#ruleNumber", rules.number);
        updateRule("#ruleSpecial", rules.special);

        // Calculate Score (0-5)
        var score = 0;
        if (rules.length) score++;
        if (rules.lower) score++;
        if (rules.upper) score++;
        if (rules.number) score++;
        if (rules.special) score++;

        // Update Bar UI and Label
        var bar = $("#strengthBar");
        var text = $("#strengthText");

        bar.removeClass("score-1 score-2 score-3 score-4 score-5");

        switch (score) {
            case 1:
            case 2:
                bar.addClass("score-1").css("width", (score * 20) + "%");
                text.text("Weak").css("color", "#ef4444");
                break;
            case 3:
                bar.addClass("score-3").css("width", "60%");
                text.text("Fair").css("color", "#f59e0b");
                break;
            case 4:
                bar.addClass("score-4").css("width", "80%");
                text.text("Good").css("color", "#3b82f6");
                break;
            case 5:
                bar.addClass("score-5").css("width", "100%");
                text.text("Strong").css("color", "#10b981");
                break;
            default:
                bar.css("width", "0%");
                text.text("Weak").css("color", "#ef4444");
                break;
        }
    });

    function updateRule(elementId, isValid) {
        if (isValid) {
            $(elementId).removeClass("invalid").addClass("valid");
        } else {
            $(elementId).removeClass("valid").addClass("invalid");
        }
    }


});