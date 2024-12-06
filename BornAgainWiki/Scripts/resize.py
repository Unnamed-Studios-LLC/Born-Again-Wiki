import os
from PIL import Image

def resize_images_in_folder(folder_path, resize_factor):
    # Ensure resize factor is valid
    if resize_factor <= 0:
        print("Resize factor must be a positive number.")
        return

    # Create an output folder
    output_folder = os.path.join(folder_path, "ResizedImages")
    os.makedirs(output_folder, exist_ok=True)

    # Get all PNG files in the folder
    png_files = [f for f in os.listdir(folder_path) if f.lower().endswith(".png")]

    if not png_files:
        print("No PNG files found in the current folder.")
        return

    for file_name in png_files:
        file_path = os.path.join(folder_path, file_name)
        try:
            # Open the image
            with Image.open(file_path) as img:
                # Calculate new dimensions
                new_width = int(img.width * resize_factor)
                new_height = int(img.height * resize_factor)

                # Resize the image
                resized_img = img.resize((new_width, new_height), Image.NEAREST)

                # Save the resized image
                resized_file_path = os.path.join(output_folder, f"{os.path.splitext(file_name)[0]}.png")
                resized_img.save(resized_file_path)

                print(f"Resized: {file_path} -> {resized_file_path}")
        except Exception as e:
            print(f"Error resizing {file_path}: {e}")

    print(f"All PNG files resized and saved to: {output_folder}")

if __name__ == "__main__":
    # Get the current folder
    current_folder = os.getcwd()
    print(f"Folder: {current_folder}")

    # Ask for resize factor
    try:
        resize_factor = float(input("Enter the resize factor (e.g., 0.5 for 50% size): "))
    except ValueError:
        print("Invalid input. Please enter a numeric value.")
    else:
        resize_images_in_folder(current_folder, resize_factor)
