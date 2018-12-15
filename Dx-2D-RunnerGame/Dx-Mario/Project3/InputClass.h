#pragma once


class InputClass
{
private:
	bool m_keys[256] = { 0, };
	int m_x, m_y;


	bool mouseButton[10] = { false, };
public:
	InputClass();
	InputClass(const InputClass&);
	~InputClass();

	void Initialize();

	void KeyDown(unsigned int);
	void KeyUp(unsigned int);

	void SetMouseDown(unsigned int);
	void SetMouseUp(unsigned int);
	bool IsMouseDown(unsigned int);

	void SetMousePosition(int, int);
	void GetMousePosition(int&, int&);

	bool IsKeyDown(unsigned int);

};