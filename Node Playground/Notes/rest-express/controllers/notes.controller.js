const Note = require('../models/node.model');

exports.create = async (req, res) => {
    if (!req.body.content) {
        return res.status(400).send({
            message: "Note content can not be empty!"
        });
    }

    const note = new Note({
        title: req.body.title || "Untitled Note",
        content: req.body.content
    });

    note.save()
        .then(data => {
            res.send(data);
        }).catch(err => {
            res.sendStatus(500).send({
                message : err.message || "Some error occurred while creating ths Note."
            })
        })
};

exports.findAll = async (req, res) => {
    Note.find()
        .then(notes => {
            res.send({
                Count: notes.length,
                Notes: notes
            });
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while retrieving notes."
            });
        });
};

exports.findOne = async (req, res) => {
    Note.findById(req.params.noteId)
        .then(note => {
            if(!note) {
                res.status(404).send({
                    message: `Note not found with id ${req.params.noteId}`
                });
            }
            res.send(note);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Note not found with id " + req.params.noteId
                });  
            }

            return res.status(500).send({
                message: "Error retrieving note with id " + req.params.noteId
            });
        })
};

exports.update = async (req, res) => {
    if (!req.body.content) {
        return res.status(400).send({
            message: "Note content can not be empty"
        });
    }

    Note.findByIdAndUpdate(req.params.noteId, {
            title: req.body.title || "Untitled Note",
            content: req.body.content
        }, { new: true })
        .then(note => {
            if (!note) 
            {
                return res.status(404).send({
                    message: `Note not found with id ${req.params.noteId}`
                });
            }
            res.send(note);
        })
        .catch(err => {
            if(err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Note not found with id " + req.params.noteId
                });                
            }
            return res.status(500).send({
                message: "Error updating note with id " + req.params.noteId
            });
        });
};

exports.delete = async (req, res) => {
    Note.findByIdAndRemove(req.params.noteId)
        .then(note => {
            if (!note) {
                return res.status(404).send({
                    message: `Note not found with id ${req.params.noteId}`
                });
            }
            res.send({
                message: "Note deleted successfully!"
            });
        }).catch(err => {
            if(err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.status(404).send({
                    message: "Note not found with id " + req.params.noteId
                });                
            }
            return res.status(500).send({
                message: "Could not delete note with id " + req.params.noteId
            });
        })
};
