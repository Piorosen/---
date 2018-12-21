////////////////////////////////////////////////////////////////////////////////
// Filename: inputclass.cpp
////////////////////////////////////////////////////////////////////////////////
#include "inputclass.h"


InputClass::InputClass()
{
}


InputClass::InputClass(const InputClass& other)
{
}


InputClass::~InputClass()
{
}

void InputClass::SetMousePosition(int x, int y)
{
	m_x = x;
	m_y = y;
}
void InputClass::GetMousePosition(int &x, int &y)
{
	x = m_x;
	y = m_y;
}
	
void InputClass::Initialize()
{

	for (int i = 0; i<256; i++)
	{
		m_keys[i] = false;
	}
	m_x = 0;
	m_y = 0;
	return;
}


void InputClass::KeyDown(unsigned int input)
{
	m_keys[input] = true;
	return;
}


void InputClass::KeyUp(unsigned int input)
{
	// If a key is released then clear that state in the key array.
	m_keys[input] = false;
	return;
}

void InputClass::SetMouseDown(unsigned int key)
{
	mouseButton[key] = true;
}

void InputClass::SetMouseUp(unsigned int key)
{
	mouseButton[key] = false;
}

bool InputClass::IsMouseDown(unsigned int key)
{
	return mouseButton[key];
}


bool InputClass::IsKeyDown(unsigned int key)
{
	// Return what state the key is in (pressed/not pressed).
	return m_keys[key];
}