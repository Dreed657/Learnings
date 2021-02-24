import React from 'react';
import { useParams } from 'react-router-dom';

export const EditNote = () => {
    const params = useParams();

    return (
        <>
            <h1>Edit note</h1>
            <p>{params.id}</p>
        </>
    )
}