///reference path="_reference.js" />




$(document).ajaxStart(function () {
    $("#progress").removeClass('displaynone');
    $("#progress").addClass('displayblock');
    $("#progress").show();


}).ajaxStop(function () {
    $("#progress").removeClass('displayblock');
    $("#progress").addClass('displaynone');
    $("#progress").hide();
});





//$(function () {
//    $(".datepicker").datepicker("setDate", new Date());
//    //$("table").dataTable();
//    //$(".calendar").datepicker();
//});



//$(document).ready(function () {

//    $("#progress").removeClass('displayblock');
//    $("#progress").addClass('displaynone');
//    $("#progress").hide();

//    //$(".datepicker").datepicker({
//    //    changeMonth: true,
//    //    changeYear: true, yearRange: '1950:+10'
//    //}).datepicker("setDate", date);


//    //$('table').dataTable({
//    //    "bPaginate": false,
//    //    "bLengthChange": false,
//    //    "bFilter": true,
//    //    "bSort": false,
//    //    "bInfo": false,
//    //    "bAutoWidth": false,
//    //    "sScrollY": "200px",
//    //    "bScrollCollapse": true,
//    //    "aaSorting": [[4, "desc"]], // Column Sorting
//    //    "aaSortingFixed": [[0, 'asc']], // This can be useful for grouping rows together.
//    //    "aaSorting": [[0, 'asc'], [1, 'asc']], // Multi Column Sorting
//    //    "aoColumnDefs": [{ "bSearchable": false, "bVisible": false, "aTargets": [0] }], // DataTables with hidden columns
//    //    "bStateSave": true, // When enabled a cookie will be used to save table display information such as pagination information, display length, filtering and sorting. As such when the end user reloads the page the display display will match what thy had previously set up.
//    //    "sPaginationType": "full_numbers", // two_button (default) and full_numbers with 'first', 'previous', 'next' and 'last' buttons
//    //    "oLanguage": {
//    //        "sLengthMenu": "Display _MENU_ records per page",
//    //        "sZeroRecords": "Nothing found - sorry",
//    //        "sInfo": "Showing _START_ to _END_ of _TOTAL_ records",
//    //        "sInfoEmpty": "Showing 0 to 0 of 0 records",
//    //        "sInfoFiltered": "(filtered from _MAX_ total records)"
//    //    },
//    //    "bJQueryUI": true,
//    //    "bProcessing": true,
//    //    "bServerSide": true,
//    //    "sAjaxSource": '../ajax/sources/arrays.txt', // "../server_side/scripts/server_processing.php"
//    //    "fnServerParams": function (aoData) {
//    //        aoData.push({ "name": "more_data", "value": "my_value" }); // send a little bit of extra information to the server
//    //    },
//    //    "sServerMethod": "POST", // The default is 'GET'
//    //    "aoColumns": [{ "sTitle": "Engine", "asSorting": ["asc"] }, { "sTitle": "Browser" }, { "sTitle": "Platform" }, { "sTitle": "Version", "sClass": "center" }, { "sTitle": "Grade", "sClass": "center" }],
//    //    "aLengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
//    //    "sDom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>',
//    //    //http://www.datatables.net/release-datatables/examples/basic_init/dom.html
//    //    //l - Length changing
//    //    //f - Filtering input
//    //    //t - The table!
//    //    //i - Information
//    //    //p - Pagination
//    //    //r - pRocessing
//    //    //< and > - div elements
//    //    //<"class" and > - div with a class
//    //    "fnRowCallback": function (nRow, aData, iDisplayIndex) {
//    //        /* Append the grade to the default row class name */
//    //        if (aData[4] == "A") {
//    //            $('td:eq(4)', nRow).html('A');
//    //        }
//    //    },
//    //    "fnFooterCallback": function (nRow, aaData, iStart, iEnd, aiDisplay) {
//    //        /*Calculate the total market share for all browsers in this table (ie inc. outside
//    //        * the pagination)*/
//    //        var iTotalMarket = 0;
//    //        for (var i = 0; i < aaData.length; i++) {
//    //            iTotalMarket += aaData[i][4] * 1;
//    //        }
//    //        /* Calculate the market share for browsers on this page */
//    //        var iPageMarket = 0;
//    //        for (var i = iStart; i < iEnd; i++) {
//    //            iPageMarket += aaData[aiDisplay[i]][4] * 1;
//    //        }
//    //        /* Modify the footer row to match what we want */
//    //        var nCells = nRow.getElementsByTagName('th');
//    //        nCells[1].innerHTML = parseInt(iPageMarket * 100) / 100 +
//    //        '% (' + parseInt(iTotalMarket * 100) / 100 + '% total)';
//    //    },
//    //    "fnDrawCallback": function (oSettings) {
//    //        /* Need to redo the counters if filtered or sorted */
//    //        if (oSettings.bSorted || oSettings.bFiltered) {
//    //            this.$('td:first-child', { "filter": "applied" }).each(function (i) {
//    //                that.fnUpdate(i + 1, this.parentNode, 0, false, false);
//    //            });
//    //        }
//    //    }
//    //});



//});



//$(window).load(function () {

//    //var oTable = $("#myDataTable").dataTable({
//    //    "bServerSide": true,
//    //    "sAjaxSource": "Home/AjaxHandler",
//    //    "bProcessing": true,
//    //    "aoColumns": [
//    //                    {
//    //                        "sName": "ID",
//    //                        "bSearchable": false,
//    //                        "bSortable": false,
//    //                        "fnRender": function (oObj) {
//    //                            return '<a href=\"Company/Details/' + oObj.aData[0] + '\">View</a>';
//    //                        }
//    //                    },
//    //		            { "sName": "COMPANY_NAME" },
//    //		            { "sName": "ADDRESS" },
//    //		            { "sName": "TOWN" }
//    //    ]
//    //});


//});




$(document).ready(function () {

    $("#btnSubmitIndexForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#home-form").submit();
    });

    $("#btnSubmitGetAllPayrollsForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#payrolls-form").submit();
    });

    $("#btnSubmitProcessPayrollForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#process-payroll-form").submit();
    });

    $("#btnSubmitGetAllBanksForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#banks-form").submit();
    });

    $("#btnSubmitGetAllBenefitsForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#benefits-form").submit();
    });

    $("#btnSubmitGetAllDepartmentsForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#departments-form").submit();
    });

    $("#btnSubmitGetAllPayeeRatesForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#payee-rates-form").submit();
    });

    $("#btnSubmitGetAllNhifRatesForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#nhif-rates-form").submit();
    });

    $("#btnSubmitGetAllPayrollItemsForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#payroll-items-form").submit();
    });

    $("#btnSubmitNewNSSFComputaionForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#new-nssf-computation-form").submit();
    });

    $("#btnSubmitGetAllSettingsForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#settings-form").submit();
    });

    $("#btnSubmitGetAllTaxCalculatorForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#tax-calculator-form").submit();
    });

    $("#btnSubmitGetAllReportsForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#reports-form").submit();
    });

    $("#btnSubmitGetAllEmployersForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#employers-form").submit();
    });

    $("#btnSubmitGetAllEmployeesForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#employees-form").submit();
    });

    $("#btnSubmitGetAllRolesForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#roles-form").submit();
    });

    $("#btnSubmitGetAllUsersForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#users-form").submit();
    });

    $("#btnSubmitGetAllUSersRolesForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#user-roles-form").submit();
    });

    $("#btnSubmitGetAllRightsForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#rights-form").submit();
    });

    $("#btnSubmitHelpForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#help-form").submit();
    });

    $("#btnSubmitContactUsForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#contact-us-form").submit();
    });

    $("#btnSubmitContactsForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#contacts-form").submit();
    });

    $("#btnSubmitAboutForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#about-form").submit();
    });

    $("#btnSubmitLogOffPartialForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#log-off-partial-form").submit();
    });

    $("#btnSubmitRegisterPartialForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#register-partial-form").submit();
    });

    $("#btnSubmitLoginPartialForm").on("click", function (e) {

        e.preventDefault();

        $("#progress").removeClass('displaynone');
        $("#progress").addClass('displayblock');
        $("#progress").show();

        $("#login-partial-form").submit();
    });

    //$("#btnSubmitExternalLoginForm").on("click", function (e) {

    //    e.preventDefault();

    //    $("#progress").removeClass('displaynone');
    //    $("#progress").addClass('displayblock');
    //    $("#progress").show();

    //    $("#external-login-form").submit();
    //});





});























