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
        <div>
            {notes.length > 0 ? (
                <div>
                    { notes.map(note => (
                        <Note key={note._id} _id={note._id} title={note.title} content={note.content} />
                    ))}
                </div>
            ) : (
                    <h4 className="text-center">No Notes</h4>
                )}
        </div>
    )
}
