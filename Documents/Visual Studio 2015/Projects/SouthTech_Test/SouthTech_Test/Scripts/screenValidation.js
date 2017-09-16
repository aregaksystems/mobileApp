$(function () {

    var MAX_OPTIONS = 5;

    $('form').bootstrapValidator({
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            Name: {
                validators: {
                    stringLength: {
                        min: 2,
                    },
                    notEmpty: {
                        message: 'Please supply your first name'
                    }
                }
            },
            option: {
                validators: {
                    notEmpty: {
                        message: 'Please supply your phone number'
                    },
                    phone: {
                        country: 'Ru',
                        message: 'Please supply a vaild phone number with area code'
                    }
                }
            }
        }
    }).on('success.form.bv', function (e) {
        submit(e);
    }).on('click', '.addButton', function () {
        var $template = $('#optionTemplate'),
            $clone = $template
                            .clone()
                            .removeClass('hide')
                            .removeAttr('id')
                            .insertBefore($template),
            $option = $clone.find('[name="option"]');



    })

        // Remove button click handler
        .on('click', '.removeButton', function () {
            var $row = $(this).parents('.form-group'),
                $option = $row.find('[name="option"]');

            // Remove element containing the option
            $row.remove();


        })

        // Called after adding new field
        .on('added.field.fv', function (e, data) {
            // data.field   --> The field name
            // data.element --> The new field element
            // data.options --> The new field options

            if (data.field === 'option[]') {
                if ($('#surveyForm').find(':visible[name="option"]').length >= MAX_OPTIONS) {
                    $('#surveyForm').find('.addButton').attr('disabled', 'disabled');
                }
            }
        })

        // Called after removing the field
        .on('removed.field.fv', function (e, data) {
            if (data.field === 'option[]') {
                if ($('#surveyForm').find(':visible[name="option"]').length < MAX_OPTIONS) {
                    $('#surveyForm').find('.addButton').removeAttr('disabled');
                }
            }
        });

});