import { Button } from "@mui/material";
import { useFormikContext } from "formik";
import React from "react";

interface OmSubmitButtonProps{
    children: any,
    otherProps: any
}

export default function OmSubmitButton({children, otherProps}: OmSubmitButtonProps){
    const {submitForm} = useFormikContext();

    function handleSubmit(){
        submitForm();
    }

    const configButton = {
        ...otherProps,
        color: 'primary',
        variant: 'contained',
        fullWidth: true,
        onclick: handleSubmit
    }

    return (
        <Button {...configButton}>
            {children}
        </Button>
    );
}