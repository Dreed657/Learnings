import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Note } from './Note';

export const Home = () => {

    const [notes, setNotes] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:3000/notes')
            .then(res => {
                setNotes(res.data.Notes);
            })
    }, []);

    return (
        <>
            {notes.length > 0 ? (
                <>
                    { notes.map(note => (
                        <Note _id={note._id} title={note.title} content={note.content} />
                    ))}
                </>
            ) : (
                    <h4 className="text-center">No Notes</h4>
                )}
        </>
    )
}
