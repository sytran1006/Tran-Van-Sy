function validator(options){
    var selectorRules={};
    function getParent(element, selector){
        while (element.parentElement) {
            if(element.parentElement.matches(selector)){
                return element.parentElement;
            }
            element= element.parentElement;
        }
    }
    function validate_oninput(inputElement){
        var errorElement= getParent(inputElement, options.formGroupSelector).querySelector(options.errorSelecter);
        errorElement.innerText='';
        getParent(inputElement, options.formGroupSelector).classList.remove('invalid');
    }
    // thuc hien validate
    function validate (inputElement, rule){
        var errorMessage= rule.test(inputElement.value);
        var errorElement= getParent(inputElement, options.formGroupSelector). querySelector(options.errorSelecter);
        var rules= selectorRules[rule.selector];
        for (var i = 0; i < rules.length; i++) {
            switch (inputElement.type) {
                case 'radio':
                case 'checkbox':
                    errorMessage= rules[i](formElement.querySelector(rule.selector + ':checked'));
                    break;
                default:
                    errorMessage= rules[i](inputElement.value);
            }
            if (errorMessage) {
                break;
            }
        }
                    if(errorMessage){
                        errorElement.innerText= errorMessage;
                        getParent(inputElement, options.formGroupSelector).classList.add('invalid');
                    }else{
                        errorElement.innerText='';
                        getParent(inputElement, options.formGroupSelector).classList.remove('invalid');
                    }
                    return !errorMessage;
    }
    //lay element
    var formElement= document.querySelector(options.form);
    if (formElement) {
        //khi submit form
        formElement.onsubmit= function (e){
            e.preventDefault();
            var isFormValid=true;
            options.rules.forEach(function(rule){
                var inputElement= formElement.querySelector(rule.selector);
                var isValid= validate(inputElement, rule);
                if (!isValid) {
                    isFormValid= false;
                }
            });
                if (isFormValid) {
                    if (typeof options.onSubmit === "function") {
                        var enableInputs = formElement.querySelectorAll('[name]');
                        var formValues= Array.from(enableInputs).reduce(function (values, input){
                            switch (input.type) {
                                case "radio":
                                case'checkbox':
                                    values[input.name]=formElement.querySelector('input[name="'+ input.name +'"]:checked').value;
                                    break;
                                case "file":
                                values[input.name] = input.files;
                                break;
                                default:
                                values[input.name] = input.value;
                            }
                            return values;
                            },
                            {});
                    options.onSubmit(formValues);
                }
            }
        }
        options.rules.forEach(function(rule){
            // luu lai cac rules cho moi input
            if (Array.isArray(selectorRules[rule.selector])) {
                selectorRules[rule.selector].push(rule.test);
            }else{
                selectorRules[rule.selector] = [rule.test];
            }
            // selectorRules[rule.selector]= rule.test;
            var inputElements= formElement.querySelectorAll(rule.selector);
            Array.from(inputElements).forEach(function(inputElement){
                 //khi blur khoi input
                inputElement.onblur= function () {
                    validate(inputElement, rule);
                }
                //khi nguoi dung nhap vao
                inputElement.oninput= function () {
                    validate_oninput(inputElement);
                }
            })
        });
    }
}
validator.isRequired= function(selector){
    return{
        selector: selector,
        test: function (value) {
            if (value[0] === " ") {
                return "Please enter this field ";
            } else {
                return value.trim() ? undefined : "Please enter this field ";
            }
        }
    }
}
validator.isEmail= function(selector){
    return{
        selector: selector,
        test: function (value) {
            var regex= /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
            return regex.test(value) ? undefined : 'Please Enter email!';
        }
    }
}
validator.isPhone= function(selector){
    return{
        selector: selector,
        test: function (value) {
            // var regex1=/^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
            var regex2=/^([+|\d])+([\s|\d])+([\d])$/;
            return regex2.test(value) ? undefined : 'Enter your phone number!';
        }
    }
}
validator.checkRadio= function(selector){
    return{
        selector: selector,
        test: function (value) {
            return value ? undefined : 'Please enter this field!';
        }
    }
};
