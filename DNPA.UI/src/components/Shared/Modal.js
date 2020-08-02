import React from 'react';
/* 
Example Usage:

	<button onClick={() => openModal()}>Open modal</button>
	<Modal isOpen={isModalOpen} onClose={() => closeModal()}>
		<h1>Modal title</h1>
		<p>hello</p>
		<p><button onClick={() => closeModal()}>Close</button></p>
	</Modal>
*/

function Modal(props) {
  const close = (e) => {
    e.preventDefault();
    if (props.onClose) {
      props.onClose();
    }
  };

  if (props.isOpen === false) return null;

  let modalStyle = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    zIndex: '9999',
    background: '#ffffff',
    padding: '10px'
  };

  if (props.width && props.height) {
    modalStyle.width = props.width + 'px';
    modalStyle.height = props.height + 'px';
    modalStyle.marginLeft = '-' + props.width / 2 + 'px';
    modalStyle.marginTop = '-' + props.height / 2 + 'px';
    modalStyle.transform = null;
  }

  if (props.style) {
    for (let key in props.style) {
      modalStyle[key] = props.style[key];
    }
  }

  let backdropStyle = {
    position: 'absolute',
    width: '100%',
    height: '100%',
    top: '0px',
    left: '0px',
    zIndex: '9998',
    background: 'rgba(0, 0, 0, 0.2)'
  };

  if (props.backdropStyle) {
    for (let key in props.backdropStyle) {
      backdropStyle[key] = props.backdropStyle[key];
    }
  }

  return (
    <div className={props.containerClassName}>
      <div className={props.className} style={modalStyle}>
        {props.children}
      </div>
      {!props.noBackdrop && (
        <div
          className={props.backdropClassName}
          style={backdropStyle}
          onClick={(e) => {
            close(e);
          }}
        />
      )}
    </div>
  );
}

export default Modal;
